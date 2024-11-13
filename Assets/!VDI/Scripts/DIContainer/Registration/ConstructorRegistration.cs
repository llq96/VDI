using System;

namespace VDI
{
    public class ConstructorRegistration : Registration
    {
        private readonly Injector _injector;
        private readonly Type _type;

        private object _instance;


        public ConstructorRegistration(DIContainer container, Type type)
        {
            _injector = new Injector(container);
            _type = type;
        }

        public override object Resolve()
        {
            return _instance ??= CreateInstance();
        }

        private object CreateInstance()
        {
            return _injector.CreateInstance(_type);
        }
    }
}