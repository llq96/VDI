using System;
using System.Collections.Generic;

namespace VDI
{
    public partial class DIContainer
    {
        private DIContainer ParentContainer { get; }
        private Injector Injector { get; }

        private readonly Dictionary<Type, Registration> _registrations = new();

        internal List<IInitializable> Initializables { get; } = new();
        internal List<IStartable> Startables { get; } = new();
        internal List<IUpdatable> Updatables { get; } = new();

        public DIContainer()
        {
            Injector = new(this);
        }

        public DIContainer(DIContainer parentContainer) : this()
        {
            ParentContainer = parentContainer;
        }
    }
}