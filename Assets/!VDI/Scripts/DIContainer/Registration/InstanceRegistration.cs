namespace VDI
{
    internal class InstanceRegistration : Registration
    {
        private readonly object _instance;

        public InstanceRegistration(DIContainer container, object instance) : base(container)
        {
            _instance = instance;

            Resolve(); //force self resolve
        }

        protected override object ResolveObject() => _instance;
    }
}