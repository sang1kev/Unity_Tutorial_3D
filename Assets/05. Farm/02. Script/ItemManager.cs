using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Transform slotGroup;
    public Slot[] slots;
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private int slotAmount = 20;
    private int itemCount = 0;

    void Start()
    {
        for (int i = 0; i < slotAmount; i++)
        {
            Instantiate(slotPrefab, slotGroup);
        }

        slots = slotGroup.GetComponentsInChildren<Slot>();
    }

    public void GetItem(Crops crop)
    {
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddCrop(crop);
                itemCount++;
                break;
            }

        }
    }

    public bool CheckItemCount()
    {
        bool result = itemCount < slotAmount;

        return result;
    }

    public void UseItem()
    {
        itemCount--;
    }
}
