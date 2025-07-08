using System.Collections.Generic;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> people = new Dictionary<string, int>();

    void Start()
    {
        people.Add("James", 10);    // Key와 value
        //people.Add("James", 15);  // key 중복 허용 x 덮어쓰임
        people.Add("Jason", 10);    // value 중복 허용 o
        people.Add("Jack", 15);    
        people.Add("John", 12);    
        people.Add("Jordan", 11);    
        people.Add("Jade", 10);    

        int age = people["James"];  // key값으로 value 찾기
        Debug.Log(age);

        //string name = peaple[10]; // value로는 못찾음
        foreach(var person in people)
        {
            if(person.Value == age)
            {
                Debug.Log(person.Key);
            }
        }

        if(people.ContainsKey("J"))
        {
            Debug.Log("J인 사람이 있음");
        }

        if(people.ContainsValue(15))
        {
            Debug.Log("15인 사람이 있음");
        }
    }
}
