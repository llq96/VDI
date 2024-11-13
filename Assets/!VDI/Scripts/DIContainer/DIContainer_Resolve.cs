using System;
using System.Collections.Generic;
using UnityEngine;

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