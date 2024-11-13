using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionFieldsTests
    {
        [Test]
        public void InjectInField()
        {
            var container = new DIContainer();
            container.RegisterInstance(42);

            var instance = new ClassWithInjectedField();
            Assert.AreEqual(0, instance.InjectedField);

            container.InjectMembers(instance);

            Assert.AreEqual(42, instance.InjectedField);
        }

        private class ClassWithInjectedField
        {
            [Inject] public int InjectedField;
        }
    }
}