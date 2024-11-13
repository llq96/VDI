using UnityEngine;

namespace VDI
{
    public class TestClass : MonoBehaviour
    {
        [Inject] private TestClass2 _testClass2;

        private void Start()
        {
            Debug.Log(_testClass2);
        }

        [Inject]
        private void SomeInjectMethod(TestClass2 testClass2)
        {
            Debug.Log($"{nameof(SomeInjectMethod)} {testClass2}");
        }

        // [Inject]
        // private void WrongInjectMethod(TestClass2 testClass2, int someInt)
        // {
        //     Debug.Log($"{nameof(SomeInjectMethod)} {testClass2}");
        // }
    }
}