using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class RegistrationWithArgumentTests
    {
        [Test]
        public void RegisterType_WithArgument_CorrectField()
        {
            var container = new DIContainer();
            container.RegisterType<ClassWithInjectedField>().WithArgument(42);

            var instance = container.Resolve<ClassWithInjectedField>();

            Assert.AreEqual(42, instance.InjectedField);
        }

        [Test]
        public void RegisterType_TwoSameWithArgument_Throw()
        {
            var container = new DIContainer();

            Assert.Catch(() => { container.RegisterType<ClassWithInjectedField>().WithArgument(42).WithArgument(42); });
        }

        private class ClassWithInjectedField
        {
            [Inject] public int InjectedField;
        }
    }
}