using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class ComponentWithInterfacesExample : MonoBehaviour, IInitializable
    {
        public void Initialize()
        {
            Debug.Log("Initialize MonoBehaviour");
        }
    }
}