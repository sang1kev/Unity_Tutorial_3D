using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    private int number;

    public CharacterController cc;
    public Transform tf;
    public Rigidbody rb;
    
    void Start()
    {
        MethodA();
        MethodB();
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }
}

public partial class StudyPartial : MonoBehaviour
{
    // private int number; //  변수 이름 동일 X

    // void Start() // 함수 이름 동일 X
    // {
    //     
    // }
    
    private void MethodB()
    {
        Debug.Log("Method B");
    }
}