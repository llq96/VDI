namespace VDI
{
    internal class InstanceRegistration : Registration
    {
        private readonly object _instance;

        public InstanceRegistration(DIContainer parentContainer, object instance) : base(parentContainer)
        {
            _instance = instance;

            Resolve(); //force self resolve
        }

        protected override object ResolveObject() => _instance;
    }
}