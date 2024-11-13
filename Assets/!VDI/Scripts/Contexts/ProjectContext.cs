using UnityEngine;

namespace VDI
{
    public class ProjectContext : Context
    {
        private static ProjectContext _projectContext;
        internal static ProjectContext Instance => GetProjectContext();


        protected override DIContainer CreateContainer()
        {
            return new DIContainer(null);
        }

        private static ProjectContext GetProjectContext()
        {
            if (_projectContext == null)
            {
                var _projectContextPrefab = Resources.Load<ProjectContext>("ProjectContext");
                _projectContext = Instantiate(_projectContextPrefab);
                DontDestroyOnLoad(_projectContext.gameObject);
            }

            return _projectContext;
        }
    }
}