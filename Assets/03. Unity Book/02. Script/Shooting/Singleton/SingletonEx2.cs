using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    // 중복 생성 방지 
    public static SingletonEx2 Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
