using UnityEngine;

namespace VDI
{
    public class GameObjectContext : Context
    {
        internal DIContainer FactoryContainer { get; set; }

        protected override void Awake()
        {
            base.Awake();

            SelfInject();
        }

        private void SelfInject()
        {
            Debug.Log("SelfInject");
            Container.InjectGameObjectRecursively(gameObject, false);
        }

        protected override DIContainer CreateContainer()
        {
            return FactoryContainer;

            // var sceneContext = FindAnyObjectByType<SceneContext>();
            // return new DIContainer(sceneContext?.Container);
        }
    }
}