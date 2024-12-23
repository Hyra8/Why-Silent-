using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemID;
    public string itemName;
    public int usesRemaining = 1;
    public Canvas interactCanvas;
    public SpriteRenderer spriteRenderer;

    [Header("Inventory System")]
    public Sprite gameWorldSprite;
    public Sprite inventorySprite;
    public Sprite dragSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PickUp()
    {
        Debug.Log("Picked Up");
        gameObject.tag = "Inventory Item";
        spriteRenderer.sprite = inventorySprite;
        InventorySystem.instance.AddItem(this);
        // mở 1 trong 2 cái dưới khi chạy chính thức
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }
    public void Use()
    {
        Debug.Log("Used");
    }
}
