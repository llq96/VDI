using System;
using System.Collections.Generic;

namespace VDI
{
    public partial class DIContainer
    {
        internal DIContainer ParentContainer { get; private set; }

        private readonly Dictionary<Type, Registration> _registrations = new();

        public DIContainer()
        {
        }

        public DIContainer(DIContainer parentContainer)
        {
            ParentContainer = parentContainer;
        }
    }
}