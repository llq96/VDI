using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public abstract class Context : MonoBehaviour
    {
        internal DIContainer DIContainer { get; private set; }
        internal Injector Injector { get; private set; }

        [SerializeField] private List<MonoInstaller> _monoInstallers;

        public virtual void Awake()
        {
            DIContainer = CreateContainer();
            Injector = new Injector(DIContainer);

            InstallMonoInstallers();
        }

        protected virtual DIContainer CreateContainer()
        {
            return new DIContainer();
        }

        private void InstallMonoInstallers()
        {
            _monoInstallers.ForEach(x => x.Bind(DIContainer));
        }
    }
}