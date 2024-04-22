using UnityEngine;

public abstract class ManagerEntity : MonoBehaviour
{
    /// <summary>
    /// Untie manager from parent and do not destroy when loading a new Scene.
    /// </summary>
    public virtual void InitiliziateManager() {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}
