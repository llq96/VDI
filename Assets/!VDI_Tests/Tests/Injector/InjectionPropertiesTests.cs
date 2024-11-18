using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionPropertiesTests
    {
        [Test]
        public void Resolve_WithRegisterValue_InjectProperty()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);
            container.RegisterType<ClassWithInjectedProperty>();

            var instance = container.Resolve<ClassWithInjectedProperty>();

            Assert.AreEqual(42, instance.InjectedProperty);
        }

        [Test]
        public void Resolve_WithRegisterValue_InjectReadOnlyProperty()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);
            container.RegisterType<ClassWithInjectedGetOnlyProperty>();

            var instance = container.Resolve<ClassWithInjectedGetOnlyProperty>();

            Assert.AreEqual(42, instance.InjectedProperty);
        }


        private class ClassWithInjectedProperty
        {
            [Inject] public int InjectedProperty { get; private set; }
        }

        private class ClassWithInjectedGetOnlyProperty
        {
            [Inject] public int InjectedProperty { get; }
        }
    }
}