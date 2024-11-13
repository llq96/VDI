namespace VDI
{
    public class SceneContext : Context
    {
        public override void Awake()
        {
            base.Awake();

            Injector.InjectCurrentScene();
        }
    }
}