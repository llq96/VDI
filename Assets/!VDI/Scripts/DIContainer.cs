using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Registration> _registrations = new();

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

        public object Resolve(Type type)
        {
            if (_registrations.TryGetValue(type, out var registration))
            {
                return registration.Resolve();
            }
            else
            {
                throw new ArgumentException($"No registration for type {type}");
            }
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }

    public abstract class Registration
    {
        public abstract object Resolve();
    }

    public class SingleRegistration : Registration
    {
        private readonly object _instance;

        public SingleRegistration(object instance)
        {
            _instance = instance;
        }

        public override object Resolve() => _instance;
    }
}