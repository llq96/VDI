using System.Linq;
using UnityEngine.SceneManagement;

namespace VDI
{
    public class SceneContext : Context
    {
        protected override void Awake()
        {
            base.Awake();

            InjectCurrentScene();
        }

        private void InjectCurrentScene()
        {
            var objects = SceneManager.GetActiveScene().GetRootGameObjects().ToList();
            objects.ForEach((obj) => Container.InjectGameObjectRecursively(obj));
        }

        protected override DIContainer CreateContainer()
        {
            return new DIContainer(ProjectContext.Instance?.Container);
        }
    }
}