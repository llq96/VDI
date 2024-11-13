using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class ExampleClass1 : MonoBehaviour
    {
        [Inject]
        private void SomeInjectMethod(float projectContexValue)
        {
            Debug.Log($"{nameof(projectContexValue)} {projectContexValue}");
        }
    }
}