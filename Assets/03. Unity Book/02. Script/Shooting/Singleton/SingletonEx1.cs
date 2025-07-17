using UnityEngine;

public class SingletonEx1 : MonoBehaviour
{
    // 중복 발생 가능
    public static SingletonEx1 Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
