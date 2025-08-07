using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    // 외부 접근을 허용, 내부에서 설정 가능
    public static StudySingleton Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 현재 객체를 싱글턴 인스턴스로 설정
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }
}