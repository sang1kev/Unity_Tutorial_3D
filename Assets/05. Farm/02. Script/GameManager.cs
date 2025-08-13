using Unity.Cinemachine;
using UnityEngine;
public enum CameraState 
{ 
    OUTDOOR, FARM, ANIMAL, HOUSE 
};

public class GameManager : Singleton<GameManager>
{
    public FarmManager farm;
    public UIManager ui;
    public ItemManager item;

    public CameraState camState = CameraState.OUTDOOR;

    [SerializeField] private CinemachineClearShot clearShot;

    public void SetCamState(CameraState newState)
    {
        if (camState != newState)
        {
            camState = newState;

            foreach (var camera in clearShot.ChildCameras)
                camera.Priority = 1;

            clearShot.ChildCameras[(int)camState].Priority = 10;
        }
    }
}
