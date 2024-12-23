using UnityEngine;
using UnityEngine.UI;

public class DragObjectSystem : MonoBehaviour
{
    #region Singleton
    public static DragObjectSystem instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Canvas canvas; // Canvas chứa đối tượng
    private Image image; // Image của item sẽ gắn vào đây
    public Collider2D hitbox;
    private RectTransform rectTransform;

    public InventoryItemSlot IISlot;
    public InventoryItemSlot touchingIISlot;
    public Item dragingItem;

    public Puzzle openingPuzzle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inventory Slot"))
        {
            touchingIISlot = collision.GetComponent<InventoryItemSlot>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Inventory Slot"))
        {
            touchingIISlot = null;
        }
    }
    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        hitbox = GetComponent<Collider2D>();
    }

    private void Update()
    {
        FollowMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Attach();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (openingPuzzle != null)
            {
                openingPuzzle.OnDropingItem();
            }
            Detach();
        }
    }
    public void Attach()
    {
        if (touchingIISlot == null || touchingIISlot.item == null) return;
        IISlot = touchingIISlot;
        dragingItem = IISlot.item;
        image.sprite = IISlot.item.dragSprite;
        image.enabled = true;
    }
    public void Detach()
    {
        dragingItem = null;
        image.sprite = null;
        image.enabled = false;
    }

    public void FollowMouse()
    {
        // Lấy vị trí chuột trong hệ tọa độ màn hình
        Vector2 mousePosition = Input.mousePosition;

        // Chuyển đổi vị trí chuột từ Screen Space sang Local Space của Canvas
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, // RectTransform của Canvas
            mousePosition,
            canvas.worldCamera, // Camera của Canvas (null nếu ở chế độ Screen Space - Overlay)
            out localPoint
        );

        // Cập nhật vị trí của RectTransform
        rectTransform.anchoredPosition = localPoint;
    }
}
