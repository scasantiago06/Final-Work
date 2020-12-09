using UnityEngine;

/// <summary>
/// Class inherited by each class that restricts the instantiation of a it to one object.
/// </summary>
/// <typeparam name="T">Specific class that will implement the singleton</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                GameObject singleton = new GameObject();
                instance = singleton.AddComponent<T>();
                singleton.name = typeof(T).ToString();
            }
            return instance;
        }
        set
        {
            if (instance == null)
            {
                DontDestroyOnLoad(value.gameObject);
                instance = value;
            }
            else
            {
                Destroy(value);
            }
        }
    }

    protected virtual void Awake()
    {
        Instance = this as T;
    }

    /// <summary>
    /// Allows each class inheriting from Singleton class to use the Awake function
    /// </summary>
}