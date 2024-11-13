using System;

namespace VDI
{
    [AttributeUsage(AttributeTargets.Constructor |
                    AttributeTargets.Method |
                    AttributeTargets.Property |
                    AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}