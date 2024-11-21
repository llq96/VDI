using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class ConstructorsWithDefaultValues
    {
        [Test]
        public void ResolveViaConstructor_WithRegisterValue_InjectValue()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);
            container.RegisterType<ClassWithConstructorWithDefaultValue>();

            var instance = container.Resolve<ClassWithConstructorWithDefaultValue>();

            Assert.AreEqual(42, instance.Value);
        }

        [Test]
        public void ResolveViaConstructor_WithoutRegisterValue_UseDefaultValue()
        {
            var container = new DIContainer();
            container.RegisterType<ClassWithConstructorWithDefaultValue>();

            var instance = container.Resolve<ClassWithConstructorWithDefaultValue>();

            Assert.AreEqual(5, instance.Value);
        }

        private class ClassWithConstructorWithDefaultValue
        {
            public int Value;

            public ClassWithConstructorWithDefaultValue(int defaultValue = 5)
            {
                Value = defaultValue;
            }
        }
    }
}