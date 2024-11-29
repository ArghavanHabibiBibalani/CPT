using UnityEngine;

public abstract class PersistentSingletonMonoBehaviour<T> : SingletonMonoBehaviour<T> where T : PersistentSingletonMonoBehaviour<T>
{
    protected override void Awake()
    {
        base.Awake();

        // Make the instance persistent across scenes
        if (_instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
