using System;
using UnityEngine;

namespace VDI
{
    public partial class DIContainer
    {
        internal void InjectMembers(object target)
        {
            Injector.InjectMembers(target);
        }

        internal void InjectGameObjectRecursively(GameObject target, bool isIgnoreGameObjectContexts = true)
        {
            Injector.InjectGameObjectRecursively(target, isIgnoreGameObjectContexts);
        }

        internal object CreateInstance(Type type)
        {
            return Injector.CreateInstance(type);
        }
    }
}