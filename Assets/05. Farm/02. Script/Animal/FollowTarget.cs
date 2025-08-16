using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
    private bool isTracking = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}
