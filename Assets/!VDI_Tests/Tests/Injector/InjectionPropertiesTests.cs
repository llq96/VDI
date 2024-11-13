using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionPropertiesTests
    {
        [Test]
        public void InjectInProperty()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);

            var instance = new ClassWithInjectedProperty();
            Assert.AreEqual(0, instance.InjectedProperty);

            container.InjectMembers(instance);

            Assert.AreEqual(42, instance.InjectedProperty);
        }

        [Test]
        public void InjectInReadOnlyProperty()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);

            var instance = new ClassWithInjectedGetOnlyProperty();
            Assert.AreEqual(0, instance.InjectedProperty);

            container.InjectMembers(instance);

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