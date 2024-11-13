using UnityEngine;

namespace VDI
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void Bind(DIContainer container);
    }
}