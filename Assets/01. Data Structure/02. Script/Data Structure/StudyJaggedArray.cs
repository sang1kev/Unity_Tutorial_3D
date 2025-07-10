using UnityEngine;

public class StudyJaggedArray : MonoBehaviour
{
    public int[] array1 = new int[3];
    public int[][] jaggedArray = new int[3][];  // 같은 타입의 배열

    void Start()
    {
        array1[0] = 0;
        array1[1] = 1;
        array1[2] = 2;

        jaggedArray[0] = new int [3] {0,1,2};
        jaggedArray[1] = new int [2] {3,4};
        jaggedArray[2] = new int [4] {5,6,7,8};
    }
}
