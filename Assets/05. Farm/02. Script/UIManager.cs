using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outDoorUI;
    [SerializeField] private GameObject farmUI;
    [SerializeField] private GameObject animUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject seedUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject boardgameUI;
    public GameObject boardPvPUI;
    public GameObject boardPvEUI;

    [SerializeField] private TextMeshProUGUI farmModeText;

    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButton;
    public Button PvPButton;
    public Button PvEButton;

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
        farmModeText.text = "Choose seed and Click to plant it!";
        seedUI.SetActive(true);
    }

    private void OnHarvestButton()
    {
        GameManager.Instance.farm.SetFarmState(FarmManager.FarmState.HARVEST);
        farmModeText.text = "Click the Crops to harvest!";
        seedUI.SetActive(false);
    }

    public void ActivateFarmUI(bool isActive)
    {
        farmUI.SetActive(isActive);
    }

    public void ActivateBoardUI(bool isActive)
    {
        boardgameUI.SetActive(isActive);
    }

    public void OpenInventory(bool isActive)
    {
        inventoryUI.SetActive(isActive);
    }
}
