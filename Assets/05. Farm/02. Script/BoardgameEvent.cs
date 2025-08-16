using UnityEngine;

public class BoardgameEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCamState(CameraState.BOARD);
            GameManager.Instance.ui.ActivateBoardUI(true);
            SingleTTTCtrl.startAction?.Invoke();
            AIBoardCtrl.startAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCamState(CameraState.HOUSE);
            GameManager.Instance.ui.boardPvPUI.SetActive(false);
            GameManager.Instance.ui.boardPvEUI.SetActive(false);
            GameManager.Instance.ui.PvPButton.gameObject.SetActive(true);
            GameManager.Instance.ui.PvEButton.gameObject.SetActive(true);
            GameManager.Instance.ui.ActivateBoardUI(false);
        }
    }
}
