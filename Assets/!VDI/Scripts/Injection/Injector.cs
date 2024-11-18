using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace VDI
{
    internal class Injector
    {
        private const BindingFlags DefaultBindingFlags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        private readonly DIContainer _container;

        public Injector(DIContainer container)
        {
            _container = container;
        }

        public void InjectGameObjectRecursively(GameObject gameObject, bool isIgnoreGameObjectContexts = true)
        {
            if (isIgnoreGameObjectContexts)
            {
                if (gameObject.TryGetComponent<GameObjectContext>(out _)) return;
            }

            var components = gameObject.GetComponents<Component>().ToList();
            components.ForEach(InjectMembers);

            foreach (Transform child in gameObject.transform)
            {
                InjectGameObjectRecursively(child.gameObject);
            }
        }

        #region InjectMembers

        public void InjectMembers(object obj)
        {
            InjectFields(obj);
            InjectProperties(obj);
            InjectMethods(obj);
        }

        private void InjectFields(object obj)
        {
            var type = obj.GetType();
            var fields = type.GetFields(DefaultBindingFlags);
            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<InjectAttribute>();
                if (attribute == null) continue;

                var valueType = field.FieldType;

                var value = _container.Resolve(valueType);

                field.SetValue(obj, value);
            }
        }

        private void InjectProperties(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties(DefaultBindingFlags);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<InjectAttribute>();
                if (attribute == null) continue;

                var valueType = property.PropertyType;
                var value = _container.Resolve(valueType);

                if (property.CanWrite)
                {
                    property.SetValue(obj, value);
                }
                else
                {
                    var fields = type.GetFields(DefaultBindingFlags);
                    var field = fields.First(x =>
                        x.Name.Contains($"<{property.Name}>") && x.Name.Contains("BackingField"));
                    field.SetValue(obj, value);
                }
            }
        }

        private void InjectMethods(object obj)
        {
            var type = obj.GetType();
            var methods = type.GetMethods(DefaultBindingFlags);
            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<InjectAttribute>();
                if (attribute == null) continue;

                //TODO generic методы, override и virtual методы 

                var parameters = method.GetParameters().ToList();

                if (TryGetParameterValues(parameters, out var values))
                {
                    method.Invoke(obj, values);
                }
                else
                {
                    throw new Exception($"Can not inject {method.Name} method");
                }
            }
        }

        #endregion

        #region CreateInstance

        public object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors(DefaultBindingFlags).ToList();

            constructors = constructors.OrderByDescending(x => x.GetParameters().Length).ToList();
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters().ToList();

                if (TryGetParameterValues(parameters, out var values))
                {
                    return constructor.Invoke(values);
                }
            }

            throw new Exception("Constructor not found");
        }

        private bool TryGetParameterValues(List<ParameterInfo> parameters, out object[] values)
        {
            values = new object[parameters.Count];

            foreach (var parameter in parameters)
            {
                if (_container.TryResolve(parameter.ParameterType, out var value))
                {
                    values[parameter.Position] = value;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}