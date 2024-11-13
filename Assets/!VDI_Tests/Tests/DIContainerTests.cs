using NUnit.Framework;
using VDI;

namespace VDI_Tests
{
    public class DIContainerTests
    {
        [Test]
        public void RegisterInstance()
        {
            var container = new DIContainer();

            container.RegisterInstance(42);
            var result = container.Resolve<int>();

            Assert.AreEqual(42, result);
        }

        [Test]
        public void RegisterType()
        {
            var container = new DIContainer();

            container.RegisterType<EmptyClass>();
            var result = container.Resolve<EmptyClass>();

            Assert.NotNull(result);
            Assert.IsTrue(result.GetType() == typeof(EmptyClass));
        }

        [Test]
        public void ResolveFromParentContainer()
        {
            var parentContainer = new DIContainer();
            var childContainer = new DIContainer(parentContainer);

            parentContainer.RegisterInstance(42);
            var result = childContainer.Resolve<int>();

            Assert.AreEqual(42, result);
        }
    }
}