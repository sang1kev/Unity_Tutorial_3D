using UnityEngine;

public class BillboardCamera : MonoBehaviour
{
    private Transform mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(mainCamera.position);
    }
}
