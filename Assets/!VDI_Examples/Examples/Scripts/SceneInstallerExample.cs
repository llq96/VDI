using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class SceneInstallerExample : MonoInstaller
    {
        [SerializeField] private ExampleClass2 _exampleClass2;
        [SerializeField] private ComponentWithInterfacesExample _componentWithInterfacesExample;

        public override void Bind(DIContainer container)
        {
            container.RegisterInstance(_exampleClass2);
            container.RegisterInstance(345);

            container.RegisterType<SharpClassExample>();

            // container.RegisterInstance(new InterfacesExample());
            container.RegisterType<InterfacesExample>();

            container.RegisterInstance(_componentWithInterfacesExample);
        }
    }
}