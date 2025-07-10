using UnityEngine;

public class ObjectPoolCtrl : MonoBehaviour
{
    public ObjectPoolQueue pool;

    public Transform shootPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = pool.DequeueObj();
            bullet.transform.position = shootPos.position;
        }
    }
}
