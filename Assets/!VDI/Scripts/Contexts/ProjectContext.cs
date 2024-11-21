using UnityEngine;

namespace VDI
{
    public class ProjectContext : ContextWithInstallers
    {
        private static ProjectContext _projectContext;

        internal static ProjectContext Instance
        {
            get
            {
                if (_projectContext == null)
                {
                    var _projectContextPrefab = Resources.Load<ProjectContext>("ProjectContext");
                    if (_projectContextPrefab != null)
                    {
                        _projectContext = Instantiate(_projectContextPrefab);
                        DontDestroyOnLoad(_projectContext.gameObject);
                    }
                }

                return _projectContext;
            }
        }
    }
}