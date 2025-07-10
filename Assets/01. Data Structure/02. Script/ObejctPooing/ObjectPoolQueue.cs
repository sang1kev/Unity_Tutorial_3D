using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab;
    public Transform parent;


    void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < 100 ; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);

            EnqueueObj(obj);
        }
    }

    public void EnqueueObj(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObj()
    {
        if (objQueue.Count < 10)
        {
            CreateObject();
        }

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
