using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class InterfacesExample : IInitializable, IStartable, IUpdatable
    {
        public void Initialize()
        {
            Debug.Log("Initialize...");
        }

        public void Start()
        {
            Debug.Log("Start...");
        }

        public void Update()
        {
            Debug.Log("Update...");
        }
    }
}