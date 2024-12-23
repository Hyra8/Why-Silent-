using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    #region Singleton
    public static InventorySystem instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public InventoryItemSlot[] itemSlots;

    private void Start()
    {

    }
    public void AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                itemSlots[i].Set(item);
                break;
            }
            if (i == itemSlots.Length - 1)
            {
                Debug.Log("Inventory is fulled, can't pick up");
            }
        }
    }
    public void UpdateInventory()
    {

    }
    public void RemoveItem(int i)
    {

    }
}
