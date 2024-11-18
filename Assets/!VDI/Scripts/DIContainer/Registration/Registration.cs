using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    internal abstract class Registration : IRegistration
    {
        internal DIContainer ParentContainer { get; private set; }
        internal DIContainer SelfContainer { get; private set; }

        public object Instance { get; private protected set; }

        public bool IsInjected { get; private set; }
        public bool IsResolved { get; private set; }


        protected Registration(DIContainer parentContainer)
        {
            ParentContainer = parentContainer;
            SelfContainer = new DIContainer(ParentContainer);
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

                TryAddInList(ParentContainer.Initializables);
                TryAddInList(ParentContainer.Startables);
                TryAddInList(ParentContainer.Updatables);
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
                SelfContainer.InjectMembers(Instance);
                IsInjected = true;
            }
        }

        public IRegistration WithArgument(object argument)
        {
            SelfContainer.RegisterInstance(argument);
            return this;
        }
    }
}