namespace VDI
{
    public class SingleRegistration : Registration
    {
        private readonly object _instance;

        public SingleRegistration(object instance)
        {
            _instance = instance;
        }

        public override object Resolve() => _instance;
    }
}