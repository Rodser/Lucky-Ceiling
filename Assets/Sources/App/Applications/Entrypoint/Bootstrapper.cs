using UnityEngine;

namespace Sources.App.Applications.Entrypoint
{
    [DefaultExecutionOrder(-1)]
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            if (FindFirstObjectByType<App>() == null)
            {
                new AppFactory().Create();
            }
        }
    }
}
