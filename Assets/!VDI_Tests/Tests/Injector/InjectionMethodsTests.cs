using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionMethodsTests
    {
        [Test]
        public void Resolve_WithRegisterValue_InvokeInjectMethod()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);
            container.RegisterType<ClassWithInjectedMethod>();

            var instance = container.Resolve<ClassWithInjectedMethod>();

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