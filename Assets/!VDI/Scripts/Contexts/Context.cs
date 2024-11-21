using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public abstract class Context : MonoBehaviour
    {
        internal DIContainer Container { get; private set; }


        protected virtual void Awake()
        {
            Container = CreateContainer();

            Bind();
            Inject();

            Container.Initializables.ForEach(x => x.Initialize());
        }

        protected virtual void Bind()
        {
        }

        protected virtual void Inject()
        {
        }

        protected virtual void Start()
        {
            Container.Startables.ForEach(x => x.Start());
        }

        protected virtual void Update()
        {
            Container.Updatables.ForEach(x => x.Update());
        }

        protected virtual DIContainer CreateContainer()
        {
            return new DIContainer();
        }
    }
}