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

        private void InjectMembers(object obj)
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

                Debug.Log($"Inject field type : {fieldType} {value}");
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

                Debug.Log($"Start inject in {method.Name}");

                var parameters = method.GetParameters();
                var values = new object[parameters.Length];

                foreach (var parameter in parameters)
                {
                    values[parameter.Position] = _container.Resolve(parameter.ParameterType);
                }

                method.Invoke(obj, values);
                Debug.Log($"Inject in {method.Name} Count parameters: {parameters.Length}");
            }
        }
    }
}