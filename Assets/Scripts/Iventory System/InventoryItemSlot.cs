using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    public Item item;
    public Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void Set(Item item)
    {
        this.item = item;
        image.sprite = item.inventorySprite;
        image.enabled = true;
    }
    public void Clear()
    {
        item = null;
        image.sprite = null;
        image.enabled = false;
    }
}
