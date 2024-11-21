using System.Collections.Generic;
using UnityEngine;

namespace VDI
{
    public class ContextWithInstallers : Context
    {
        [SerializeField] private List<MonoInstaller> _monoInstallers;

        protected override void Bind()
        {
            base.Bind();
            BindMonoInstallers();
        }

        private void BindMonoInstallers()
        {
            _monoInstallers?.ForEach(x => x.Bind(Container));
        }
    }
}