using System;

namespace VDI
{
    internal class ConstructorRegistration : Registration
    {
        private readonly Type _type;


        public ConstructorRegistration(DIContainer parentContainer, Type type) : base(parentContainer)
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
            return SelfContainer.CreateInstance(_type);
        }
    }
}