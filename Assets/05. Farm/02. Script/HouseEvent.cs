using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private GameObject houseTop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.transform.position += Vector3.up * 13f;
            GameManager.Instance.SetCamState(CameraState.HOUSE);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.transform.position += Vector3.up * -13f;
            GameManager.Instance.SetCamState(CameraState.OUTDOOR);
        }
    }
}
