using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class SceneInstallerExample : MonoInstaller
    {
        [SerializeField] private ExampleClass2 _exampleClass2;
        [SerializeField] private ComponentWithInterfacesExample _componentWithInterfacesExample;

        [SerializeField] private PrefabClassExample _prefab;


        public override void Bind(DIContainer container)
        {
            // container.RegisterInstance(_exampleClass2);
            // container.RegisterInstance(345);
            // container.RegisterInstance(new InterfacesExample());
            // container.RegisterType<InterfacesExample>();
            // container.RegisterInstance(_componentWithInterfacesExample);

            // container.RegisterType<SharpClassExample>().WithArgument(456);
            // container.Resolve<SharpClassExample>();


            // container.RegisterInstance(345);
            container.RegisterPrefabFactory(_prefab).WithArgument(543);

            var factory = container.ResolveFactoryFor<PrefabClassExample>();
            factory.Create();
        }
    }
}