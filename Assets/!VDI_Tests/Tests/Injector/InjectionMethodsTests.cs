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
            container.RegisterInstance(42);

            var instance = new ClassWithInjectedMethod();
            Assert.AreEqual(0, instance.InjectedValue);

            container.RegisterInstance(instance);

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