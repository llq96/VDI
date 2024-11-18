using UnityEngine;

namespace VDI
{
    public sealed class PrefabFactory<TPrefab> where TPrefab : Component
    {
        private TPrefab Prefab { get; }
        internal Registration Registration { get; set; }

        public PrefabFactory(TPrefab prefab)
        {
            Prefab = prefab;
        }


        public TPrefab Create()
        {
            var isPrefabWasActive = Prefab.gameObject.activeSelf;
            Prefab.gameObject.SetActive(false);

            var instance = Object.Instantiate(Prefab);
            var gameObjectContext = instance.gameObject.AddComponent<GameObjectContext>();

            // Debug.Log("GameObjectContext added");
            gameObjectContext.FactoryContainer = Registration.SelfContainer;

            if (isPrefabWasActive)
            {
                Prefab.gameObject.SetActive(true);
                instance.gameObject.SetActive(true);
            }

            return instance;
        }
    }
}