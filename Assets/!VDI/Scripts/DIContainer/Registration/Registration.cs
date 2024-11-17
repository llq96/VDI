using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    internal abstract class Registration
    {
        protected readonly DIContainer Container;

        public object Instance { get; private protected set; }

        public bool IsInjected { get; private set; }
        public bool IsResolved { get; private set; }

        protected Registration(DIContainer container)
        {
            Container = container;
        }

        public object Resolve()
        {
            if (!IsResolved)
            {
                Instance = ResolveObject();
                IsResolved = true;
                TryInjectMembers();

                if (Instance is MonoBehaviour && (Instance is IStartable || Instance is IUpdatable))
                    throw new Exception("IStartable and IUpdatable interfaces are not supported for MonoBehaviours.");

                TryAddInList(Container.Initializables);
                TryAddInList(Container.Startables);
                TryAddInList(Container.Updatables);
            }

            return Instance;
        }

        private void TryAddInList<T>(List<T> list)
        {
            if (Instance is T realization)
            {
                list.Add(realization);
            }
        }

        protected abstract object ResolveObject();

        private void TryInjectMembers()
        {
            if (!IsInjected)
            {
                Container.InjectMembers(Instance);
                IsInjected = true;
            }
        }
    }
}