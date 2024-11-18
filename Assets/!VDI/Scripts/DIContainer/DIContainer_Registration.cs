using System;

namespace VDI
{
    public partial class DIContainer
    {
        private Registration InternalRegister(Type type, Registration registration)
        {
            _registrations.Add(type, registration);
            // Debug.Log($"Register {type} as {registration.GetType()} ");
            return registration;
        }

        private void ThrowIfContainsRegistration(Type type)
        {
            if (_registrations.ContainsKey(type))
            {
                throw new ArgumentException($"Type {type} is already registered ");
            }
        }

        #region RegisterInstance

        public IRegistration RegisterInstance(object instance)
        {
            var type = instance.GetType();
            ThrowIfContainsRegistration(type);

            var registration = new InstanceRegistration(this, instance);

            return InternalRegister(type, registration);
        }

        #endregion

        #region RegisterType

        public IRegistration RegisterType<T>()
        {
            return RegisterType(typeof(T));
        }

        public IRegistration RegisterType(Type type)
        {
            ThrowIfContainsRegistration(type);

            var registration = new ConstructorRegistration(this, type);

            return InternalRegister(type, registration);
        }

        #endregion
    }
}