using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "**Hello**";
    public string[] str2 = new string[4] { "Hello", "Hi", "Sup", " S p a c e " };
    public string str3 = "**.*.Hello.*.**";

    void Start()
    {
        Debug.Log(str1[0]);
        Debug.Log(str2[0]);

        Debug.Log(str1.Length);
        Debug.Log(str2[3].Trim());      // 앞뒤 제거
        Debug.Log(str1);
        Debug.Log(str1.Trim('*'));
        Debug.Log(str3.Trim('*'));
        Debug.Log(str1.ToUpper());
        Debug.Log(str1.ToLower());
        Debug.Log(str1.Replace("ello", "ola"));

        string text = "Apple, Banana, Peach";
        string[] fruits = text.Split(',');

        foreach (string fruit in fruits)
        {
            fruit.Trim();
            Debug.Log($"{fruit}");
        }
    }
}
