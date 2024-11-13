using System;
using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public class Context : MonoBehaviour
    {
        protected DIContainer Container { get; } = new();
        protected Injector Injector { get; private set; }

        [SerializeField] private List<MonoInstaller> _monoInstallers;

        public virtual void Awake()
        {
            Injector = new Injector(Container);

            InstallMonoInstallers();
        }

        private void InstallMonoInstallers()
        {
            _monoInstallers.ForEach(x => x.Bind(Container));
        }
    }
}