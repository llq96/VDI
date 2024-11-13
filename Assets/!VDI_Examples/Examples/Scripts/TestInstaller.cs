using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class TestInstaller : MonoInstaller
    {
        [SerializeField] private TestClass2 _testClass2;

        public override void Bind(DIContainer container)
        {
            container.RegisterInstance(_testClass2);
            container.RegisterInstance(345);

            container.RegisterType<SharpClass>();
        }
    }
}