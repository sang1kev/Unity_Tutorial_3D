using UnityEngine;

public class SingletonEx3 : MonoBehaviour
{
    // singleton을 만들 때 MonoBehaviour는 new 키워드 사용을 하면 안됨

    private static SingletonEx3 instance = new SingletonEx3();
    public static SingletonEx3 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonEx3();
            }

            return instance;
        }
    }
}
