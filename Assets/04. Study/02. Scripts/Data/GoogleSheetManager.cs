using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public string URL;

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        WWWForm form = new WWWForm();
        form.AddField("value", "123");
        
        UnityWebRequest www2 = UnityWebRequest.Post(URL, form);
        yield return www2.SendWebRequest();

        string data = www.downloadHandler.text;
        
        Debug.Log(data);
    }
}