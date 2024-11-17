namespace VDI
{
    public interface IInitializable
    {
        void Initialize();
    }

    public interface IStartable
    {
        void Start();
    }

    public interface IUpdatable
    {
        void Update();
    }
}