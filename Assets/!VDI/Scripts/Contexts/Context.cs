using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public abstract class Context : MonoBehaviour
    {
        internal DIContainer Container { get; private set; }

        [SerializeField] private List<MonoInstaller> _monoInstallers;


        protected virtual void Awake()
        {
            Container = CreateContainer();

            InstallMonoInstallers();

            Container.Initializables.ForEach(x => x.Initialize());
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

        private void InstallMonoInstallers()
        {
            _monoInstallers?.ForEach(x => x.Bind(Container));
        }
    }
}