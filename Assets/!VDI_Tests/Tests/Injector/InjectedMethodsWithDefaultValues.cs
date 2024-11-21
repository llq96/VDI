using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectedMethodsWithDefaultValues
    {
        [Test]
        public void InjectInMethod_WithRegisterValue_InjectValue()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);
            container.RegisterType<ClassWithMethodWithDefaultValue>();

            var instance = container.Resolve<ClassWithMethodWithDefaultValue>();

            Assert.AreEqual(42, instance.Value);
        }

        [Test]
        public void InjectInMethod_WithoutRegisterValue_UseDefaultValue()
        {
            var container = new DIContainer();
            container.RegisterType<ClassWithMethodWithDefaultValue>();

            var instance = container.Resolve<ClassWithMethodWithDefaultValue>();

            Assert.AreEqual(5, instance.Value);
        }

        private class ClassWithMethodWithDefaultValue
        {
            public int Value;

            [Inject]
            public void MethodWithDefaultValue(int defaultValue = 5)
            {
                Value = defaultValue;
            }
        }
    }
}