using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    // 어떤 타입이든 받을 수 있게 만듦

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var t = FindFirstObjectByType<T>();
                if (t != null)
                {
                    instance = t;
                }
                else
                {
                    var newObj = new GameObject();
                    newObj.AddComponent<T>();

                    instance = newObj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
