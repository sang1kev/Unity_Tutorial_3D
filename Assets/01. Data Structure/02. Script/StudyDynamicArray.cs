using System.Collections.Generic;
using UnityEngine;

public class StudyDynamicArray : MonoBehaviour
{
    // boxing and unboxing으로 인해 object는 잘 안쓰임
    private object[] array = new object[3];

    void AddArray(object o)
    {
        var temp = new object[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        array = temp;
        array[array.Length - 1] = o;
    }


    // 리스트를 사용하여 바로 작동
    public List<int> list1 = new List<int>();
    public List<int> list2 = new List<int>() { 1,2,3,4 };
    public List<int> list3;
    private List<int> list4;
    private List<int> list5 = new List<int>();

    public List<int> list6 = new List<int> () { 1,2,3 };

    void Start()
    {
        list1.Add(10);
        list2.Add(10);
        list3.Add(10);      // public 시 unity 상에서 수정 o 작동 o
        // list4.Add(10);   // private 시 unity 상에서 수정 x 작동 x
        list5.Add(10);

        list6.Add(10);
        for (int i = 0; i < 10; i++)
        {
            list6.Add (i);
        }

        list6.Insert(6, 100);

        list6.Remove(10);

        list2.RemoveAll(x => x >= 3);

        if(list3.Contains(10))
        {
            Debug.Log("값 존재");
        }
        else
        {
            Debug.Log("값 없음");
        }
    }

}
