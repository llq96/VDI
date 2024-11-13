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
            var injector = new Injector(container);

            container.RegisterInstance(42);

            var instance = new ClassWithInjectedProperty();
            Assert.AreEqual(0, instance.InjectedProperty);

            injector.InjectMembers(instance);

            Assert.AreEqual(42, instance.InjectedProperty);
        }

        private class ClassWithInjectedProperty
        {
            [Inject] public int InjectedProperty { get; private set; }
        }
    }
}