using UnityEngine;

namespace VDI
{
    public static class InjectExtensions
    {
        public static void InjectMembers(this DIContainer container, object target)
        {
            var injector = new Injector(container);
            injector.InjectMembers(target);
        }

        public static void InjectGameObjectRecursively(this DIContainer container, GameObject target)
        {
            var injector = new Injector(container);
            injector.InjectGameObjectRecursively(target);
        }
    }
}