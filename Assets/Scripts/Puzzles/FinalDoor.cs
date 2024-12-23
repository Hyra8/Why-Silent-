using UnityEngine;

public class FinalDoor : Puzzle
{
    [SerializeField] string goldenLockKeyID = "final key 1";
    [SerializeField] string silverLockKeyID = "final key 2";
    [SerializeField] Collider2D keyHoleCollider1;
    [SerializeField] Collider2D keyHoleCollider2;
    DragObjectSystem dragObjectSystem;
    [SerializeField] GameObject goldenLock;
    [SerializeField] GameObject silverLock;
    Animator animator;

    bool stayTrigger1 = false;
    bool stayTrigger2 = false;

    private void Start()
    {
        player = Player.instance;
        dragObjectSystem = DragObjectSystem.instance;
        animator = GetComponent<Animator>();
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
        if (stayTrigger1 && dragObjectSystem.dragingItem.itemID == goldenLockKeyID)
        {
            UnLockGoldenLock();
        }
        if (stayTrigger2 && dragObjectSystem.dragingItem.itemID == silverLockKeyID)
        {
            UnlockSilverLock();
        }
    }
    public void UnLockGoldenLock()
    {
        goldenLock.SetActive(false);
        DragObjectSystem.instance.IISlot.Clear();
        stayTrigger1 = false;

        if (!silverLock.activeSelf)
        {
            isSolved = true;
        }
    }
    public void UnlockSilverLock()
    {
        silverLock.SetActive(false);
        DragObjectSystem.instance.IISlot.Clear();
        stayTrigger2 = false;

        if (!goldenLock.activeSelf)
        {
            isSolved = true;
        }
    }
    private void MyOnTriggerStay2D()
    {
        if (dragObjectSystem.dragingItem == null || stayTrigger1) return;
        if (keyHoleCollider1.IsTouching(dragObjectSystem.hitbox))
        {
            stayTrigger1 = true;
        }
        if (keyHoleCollider2.IsTouching(dragObjectSystem.hitbox))
        {
            stayTrigger2 = true;
        }
    }
    private void MyOnTriggerExit2D()
    {
        if (dragObjectSystem.dragingItem == null || !stayTrigger1) return;
        if (!keyHoleCollider1.IsTouching(dragObjectSystem.hitbox) &&
            !keyHoleCollider2.IsTouching(dragObjectSystem.hitbox))
        {
            stayTrigger1 = false;
            stayTrigger2 = false;
        }
    }
    public void EndGame()
    {
        Debug.Log("END GAME");
    }
    public void TryOpenDoor()
    {
        Debug.Log("a");
        if (isSolved)
        {
            EndGame();
        }
        else
        {
            animator.Play("TryOpen");
        }
    }
}
