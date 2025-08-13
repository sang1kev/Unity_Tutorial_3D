using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private int camNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCamState(CameraState.FARM);
            GameManager.Instance.ui.ActivateFarmUI(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCamState(CameraState.OUTDOOR);
            GameManager.Instance.ui.ActivateFarmUI(false);
        }
    }
}
