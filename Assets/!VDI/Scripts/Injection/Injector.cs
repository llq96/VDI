using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VDI
{
    public class Injector
    {
        private const BindingFlags DefaultBindingFlags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;


        private DIContainer _container;

        public Injector(DIContainer container)
        {
            _container = container;
        }

        public void InjectCurrentScene()
        {
            var objects = SceneManager.GetActiveScene().GetRootGameObjects().ToList();

            objects.ForEach(InjectGameObjectRecursively);
        }

        public void InjectGameObjectRecursively(GameObject gameObject)
        {
            var components = gameObject.GetComponents<Component>().ToList();
            components.ForEach(InjectMembers);

            foreach (Transform child in gameObject.transform)
            {
                InjectGameObjectRecursively(child.gameObject);
            }
        }

        public void InjectMembers(object obj)
        {
            InjectFields(obj);
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

                var fieldType = field.FieldType;

                var value = _container.Resolve(fieldType);

                field.SetValue(obj, value);
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


                var parameters = method.GetParameters();
                var values = new object[parameters.Length];

                foreach (var parameter in parameters)
                {
                    values[parameter.Position] = _container.Resolve(parameter.ParameterType);
                }

                method.Invoke(obj, values);
            }
        }

        public object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors(DefaultBindingFlags).ToList();

            constructors = constructors.OrderByDescending(x => x.GetParameters().Length).ToList();
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters().ToList();

                if (TryGetParameterValues(parameters, out var values))
                {
                    var instance = constructor.Invoke(values);
                    InjectMembers(instance);
                    return instance;
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
    }
}