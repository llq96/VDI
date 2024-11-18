using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class PrefabClassExample : MonoBehaviour
    {
        [Inject] private void Construct(float floatFromProjectContext)
        {
            Debug.Log($"{nameof(PrefabClassExample)} {nameof(floatFromProjectContext)} {floatFromProjectContext}");
        }

        [Inject]
        private void SomeInjectMethod2(int intValue)
        {
            Debug.Log($"{nameof(PrefabClassExample)} {nameof(intValue)} {intValue}");
        }
    }
}