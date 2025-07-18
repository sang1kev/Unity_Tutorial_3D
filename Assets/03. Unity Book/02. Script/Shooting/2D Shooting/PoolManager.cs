using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateObj, OnGetObj, OnReleaseObj, OnDestroyObj);
    }

    private GameObject CreateObj()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObj(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        obj.transform.position = Vector3.zero;

        obj.SetActive(true);
    }

    private void OnReleaseObj(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyObj(GameObject obj)
    {
        Destroy(obj);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.Get();
            obj.SetActive(true); 
        }
    }
}
