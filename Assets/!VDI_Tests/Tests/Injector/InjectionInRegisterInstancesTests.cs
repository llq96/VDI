using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class InjectionInRegisterInstancesTests
    {
        [Test]
        public void InjectAfterRegistration()
        {
            var container = new DIContainer();
            var obj1 = new Type1();
            container.RegisterInstance(obj1);
            var obj2 = new Type2();

            Assert.AreEqual(null, obj2.InjectedField);

            container.RegisterInstance(obj2);

            Assert.AreEqual(obj1, obj2.InjectedField);
        }

        private class Type1
        {
        }

        private class Type2
        {
            [Inject] public Type1 InjectedField;
        }
    }
}