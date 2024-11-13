using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class SharpClass
    {
        [Inject] private TestClass2 _testClass2;

        public SharpClass()
        {
            Debug.Log("Empty Constructor");
        }

        [Inject]
        private void SomeInjectMethod(TestClass2 testClass2)
        {
            Debug.Log($"TestClass2 from field{_testClass2}");
            Debug.Log($"{nameof(SomeInjectMethod)} {testClass2}");
        }
    }
}