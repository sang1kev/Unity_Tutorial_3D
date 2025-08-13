using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outDoorUI;
    [SerializeField] private GameObject farmUI;
    [SerializeField] private GameObject animUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject seedUI;

    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButton;

    void Awake()
    {
        seedButton.onClick.AddListener(OnSeedButton);
        harvestButton.onClick.AddListener(OnHarvestButton);

        for (int i = 0; i < plantButton.Length; i++)
        {
            int j = i;
            plantButton[i].onClick.AddListener(() => GameManager.Instance.farm.SetPlant(j));
        }
    }

    private void OnSeedButton()
    {
        GameManager.Instance.farm.SetFarmState(FarmManager.FarmState.SEED);
        seedUI.SetActive(true);
    }

    private void OnHarvestButton()
    {
        GameManager.Instance.farm.SetFarmState(FarmManager.FarmState.HARVEST);
        seedUI.SetActive(true);
    }

    public void ActivateFarmUI(bool isActive)
    {
        farmUI.SetActive(isActive);
    }
}
