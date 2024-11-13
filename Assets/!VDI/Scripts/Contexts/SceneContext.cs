namespace VDI
{
    public class SceneContext : Context
    {
        public override void Awake()
        {
            base.Awake();

            Injector.InjectCurrentScene();
        }

        protected override DIContainer CreateContainer()
        {
            return new DIContainer(ProjectContext.Instance.DIContainer);
        }
    }
}