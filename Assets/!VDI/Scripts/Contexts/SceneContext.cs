using System.Linq;
using UnityEngine.SceneManagement;

namespace VDI
{
    public class SceneContext : Context
    {
        public override void Awake()
        {
            base.Awake();

            InjectCurrentScene();
        }

        private void InjectCurrentScene()
        {
            var objects = SceneManager.GetActiveScene().GetRootGameObjects().ToList();
            objects.ForEach(Injector.InjectGameObjectRecursively);
        }

        protected override DIContainer CreateContainer()
        {
            return new DIContainer(ProjectContext.Instance?.DIContainer);
        }
    }
}