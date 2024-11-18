using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionFieldsTests
    {
        [Test]
        public void Resolve_WithRegisterValue_InjectField()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);
            container.RegisterType<ClassWithInjectedField>();

            var instance = container.Resolve<ClassWithInjectedField>();

            Assert.AreEqual(42, instance.InjectedField);
        }

        private class ClassWithInjectedField
        {
            [Inject] public int InjectedField;
        }
    }
}