using UnityEngine;
using VDI;

namespace VDI_Examples
{
    public class SharpClassExample
    {
        [Inject] private ExampleClass2 _exampleClass2;
        [Inject] private int _intValue;

        public SharpClassExample()
        {
            Debug.Log("Empty Constructor");
        }

        [Inject]
        private void SomeInjectMethod(ExampleClass2 exampleClass2)
        {
            Debug.Log($"TestClass2 from field{_exampleClass2}");
            Debug.Log($"{nameof(SomeInjectMethod)} {exampleClass2}");
            Debug.Log($"{nameof(_intValue)} {_intValue}");
        }
    }
}