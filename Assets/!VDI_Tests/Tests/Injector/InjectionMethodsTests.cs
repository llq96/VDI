using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionMethodsTests
    {
        [Test]
        public void InjectInMethod()
        {
            var container = new DIContainer();
            var injector = new Injector(container);

            container.RegisterInstance(42);

            var instance = new ClassWithInjectedMethod();
            Assert.AreEqual(0, instance.InjectedValue);

            injector.InjectMembers(instance);

            Assert.AreEqual(42, instance.InjectedValue);
        }

        private class ClassWithInjectedMethod
        {
            public int InjectedValue;

            [Inject]
            private void Inject(int value)
            {
                InjectedValue = value;
            }
        }
    }
}