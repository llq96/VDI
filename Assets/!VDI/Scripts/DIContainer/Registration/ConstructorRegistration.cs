using System;

namespace VDI
{
    internal class ConstructorRegistration : Registration
    {
        private readonly Type _type;


        public ConstructorRegistration(DIContainer container, Type type) : base(container)
        {
            _type = type;

            if (typeof(IInitializable).IsAssignableFrom(_type) || typeof(IStartable).IsAssignableFrom(_type))
            {
                Resolve(); //force self resolve
            }
        }

        protected override object ResolveObject()
        {
            return Instance ??= CreateInstance();
        }

        private object CreateInstance()
        {
            return Container.CreateInstance(_type);
        }
    }
}