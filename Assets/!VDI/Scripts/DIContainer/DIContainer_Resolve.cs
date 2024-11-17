using System;
using System.Linq;

namespace VDI
{
    public partial class DIContainer
    {
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
            if (_registrations.TryGetValue(type, out var registration))
            {
                instance = registration.Resolve();
                return true;
            }

            if (ParentContainer != null)
            {
                return ParentContainer.TryResolve(type, out instance);
            }

            instance = null;
            return false;
        }


        public bool TryResolve<T>(out object instance)
        {
            return TryResolve(typeof(T), out instance);
        }

        #endregion
    }
}