using UnityEngine;

namespace VDI
{
    public class TestInstaller : MonoInstaller
    {
        [SerializeField] private TestClass2 _testClass2;


        public override void Bind(DIContainer container)
        {
            container.RegisterInstance(_testClass2);
        }
    }
}