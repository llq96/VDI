using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class ExampleClass1 : MonoBehaviour
    {
        [Inject]
        private void SomeInjectMethod(float projectContextValue)
        {
            Debug.Log($"{nameof(projectContextValue)} {projectContextValue}");
        }
    }
}