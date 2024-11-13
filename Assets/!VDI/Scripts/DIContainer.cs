using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public class DIContainer
    {
        internal DIContainer ParentContainer { get; private set; }

        private readonly Dictionary<Type, Registration> _registrations = new();

        public DIContainer(DIContainer parentContainer)
        {
            ParentContainer = parentContainer;
        }

        #region RegisterInstance

        public void RegisterInstance<T>(T instance)
        {
            if (_registrations.ContainsKey(instance.GetType()))
            {
                throw new ArgumentException($"Instance of type {instance.GetType()} is already registered");
            }

            var registration = new SingleRegistration(instance);

            _registrations.Add(typeof(T), registration);
            Debug.Log($"Registering instance of type {instance.GetType()}");
        }

        #endregion

        #region RegisterType

        public void RegisterType<T>()
        {
            RegisterType(typeof(T));
        }

        public void RegisterType(Type type)
        {
            if (_registrations.ContainsKey(type))
            {
                throw new ArgumentException($"Type {type} is already registered ");
            }

            var registration = new ConstructorRegistration(this, type);
            _registrations.Add(type, registration);
            Debug.Log($"Registering type {type}");
        }

        #endregion

        #region Resolve

        public object Resolve(Type type)
        {
            if (TryResolve(type, out var instance))
            {
                return instance;
            }

            throw new Exception($"Could not resolve type {type}");
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        #endregion

        #region TryResolve

        public bool TryResolve(Type type, out object instance)
        {
            instance = null;
            if (_registrations.TryGetValue(type, out var registration))
            {
                instance = registration.Resolve();
                return true;
            }

            if (ParentContainer != null)
            {
                return ParentContainer.TryResolve(type, out instance);
            }

            return false;
        }


        public bool TryResolve<T>(out object instance)
        {
            return TryResolve(typeof(T), out instance);
        }

        #endregion
    }
}