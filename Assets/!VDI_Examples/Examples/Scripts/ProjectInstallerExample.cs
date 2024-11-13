using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class ProjectInstallerExample : MonoInstaller
    {
        public override void Bind(DIContainer container)
        {
            container.RegisterInstance(123f);
        }
    }
}