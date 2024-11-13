using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public partial class DIContainer
    {
        private void Register(Type type, Registration registration)
        {
            _registrations.Add(type, registration);
            // Debug.Log($"Register {type} as {registration.GetType()} ");
        }

        private void ThrowIfContainsRegistration(Type type)
        {
            if (_registrations.ContainsKey(type))
            {
                throw new ArgumentException($"Type {type} is already registered ");
            }
        }

        #region RegisterInstance

        public void RegisterInstance<T>(T instance)
        {
            ThrowIfContainsRegistration(typeof(T));

            var registration = new SingleRegistration(instance);

            Register(typeof(T), registration);
        }

        #endregion

        #region RegisterType

        public void RegisterType<T>()
        {
            RegisterType(typeof(T));
        }

        public void RegisterType(Type type)
        {
            ThrowIfContainsRegistration(type);

            var registration = new ConstructorRegistration(this, type);

            Register(type, registration);
        }

        #endregion
    }
}