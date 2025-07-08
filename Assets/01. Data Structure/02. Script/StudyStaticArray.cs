using UnityEngine;

public class StudyStaticArray : MonoBehaviour
{
    int[] array1;                       // 배열 선언
    int[] array2 = {10,20,30,40,50};    // 배열 선언과 초기화
    int[] array3 = new int[5];          // 공간 할당
    int[] array4 = new int[5] {10,20,30,40,50};     // 선언, 공간 할당, 초기화

    void Start()
    {
        array1 = new int[5];            // 공간 할당
        // 공간 할당 후 크기 수정 x
    }
}
