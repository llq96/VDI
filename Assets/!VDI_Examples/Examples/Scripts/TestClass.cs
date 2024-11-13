using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class TestClass : MonoBehaviour
    {
        [Inject]
        private void SomeInjectMethod(float projectContexValue)
        {
            Debug.Log($"{nameof(projectContexValue)} {projectContexValue}");
        }
    }
}