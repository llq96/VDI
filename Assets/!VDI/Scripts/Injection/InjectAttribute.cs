using System;

namespace VDI
{
    [AttributeUsage(AttributeTargets.Method |
                    AttributeTargets.Property |
                    AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}