using UnityEngine;

public class Crops : MonoBehaviour
{
    [SerializeField] private string name;
    public Sprite icon;

    [SerializeField] 
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Get();
        }
    }

    public void Get()
    {
        if (GameManager.Instance.item.CheckItemCount())
        {
            GameManager.Instance.item.GetItem(this);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }

    public void Use()
    {

    }
}
