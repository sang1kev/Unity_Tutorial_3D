using UnityEngine;

public class SaveService : MonoBehaviour, ISaveService
{
    public void SaveData()
    {
        Debug.Log("Save Data");
    }

    public void LoadData()
    {
        Debug.Log("Load Data");
    }
}