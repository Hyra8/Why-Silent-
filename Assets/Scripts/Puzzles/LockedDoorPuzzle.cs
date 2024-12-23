using UnityEngine;
using UnityEngine.UI;

public class LockedDoorPuzzle : Puzzle
{
    [SerializeField] string keyID = "key0";
    [SerializeField] Collider2D keyHoleCollider;
    [SerializeField] GameObject unlockedTextBox;
    DragObjectSystem dragObjectSystem;
    [SerializeField] Image doorImage;
    [SerializeField] Sprite unlockedSprite;
    [SerializeField] GameObject potal;
    [SerializeField] Vector3 playerNewPos;

    bool stayTrigger = false;

    private void Start()
    {
        player = Player.instance;
        dragObjectSystem = DragObjectSystem.instance;
    }
    public override void OnDropingItem()
    {
        Check();
    }

    private void Update()
    {
        if (!isSolved)
        {
            MyOnTriggerStay2D();
            MyOnTriggerExit2D();
        }
        if (Input.GetMouseButtonDown(1) && !player.canMove)
        {
            ClosePuzzle();
        }
    }
    public void Check()
    {
        if (stayTrigger && dragObjectSystem.dragingItem.itemID == keyID)
        {
            UnLockDoor();
        }
    }
    public void UnLockDoor()
    {
        doorImage.sprite = unlockedSprite;
        DragObjectSystem.instance.IISlot.Clear();
        unlockedTextBox.SetActive(true);
        stayTrigger = false;
        isSolved = true;
        Player.instance.transform.position = transform.position + playerNewPos;
        potal.SetActive(true);
    }
    public override void ClosePuzzle()
    {
        base.ClosePuzzle();
        //if (isSolved )
        //{
        //    // SetActive teleport
        //    gameObject.SetActive(false);
        //}
    }
    private void MyOnTriggerStay2D()
    {
        if (dragObjectSystem.dragingItem == null || stayTrigger) return;
        if (keyHoleCollider.IsTouching(dragObjectSystem.hitbox))
        {
            stayTrigger = true;
        }
    }
    private void MyOnTriggerExit2D()
    {
        if (dragObjectSystem.dragingItem == null || !stayTrigger) return;
        if (!keyHoleCollider.IsTouching(dragObjectSystem.hitbox))
        {
            stayTrigger = false;
        }
    }
}
