using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("Other Objects")]
    StateMachine stateMachine;
    public GameManager gameManager;
    public Puzzle puzzle; // Chứa puzzle được va chạm với collider
    [SerializeField] Item item;
    [SerializeField] HideSpot hideSpot;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] Animator outfitAnimator;
    [SerializeField] Transform interactArea;
    private Rigidbody2D rb;
    private Collider2D body;
    bool hiding = false;
    [SerializeField] SpriteRenderer outfit;

    [Header("Base")]
    public float speed = 5f;
    public bool canMove = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle"))
        {
            puzzle = collision.GetComponent<Puzzle>();
            if (puzzle.highlightCanvas != null)
            {
                puzzle.highlightCanvas.gameObject.SetActive(true);
            }
        }
        if (collision.CompareTag("Item"))
        {
            item = collision.GetComponent<Item>();
            if (item.interactCanvas != null)
            {
                item.interactCanvas.gameObject.SetActive(true);
            }
        }
        if (collision.CompareTag("Hide Spot"))
        {
            hideSpot = collision.GetComponent<HideSpot>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle") && puzzle != null)
        {
            if (puzzle.highlightCanvas != null)
            {
                puzzle.highlightCanvas.gameObject.SetActive(false);
            }
            puzzle = null;
        }
        if (collision.CompareTag("Item") && item != null) // Vì lí do nào đấy mà nếu không thêm item != null vào thì sẽ bị lỗi
        {
            if (item.interactCanvas != null)
            {
                item.interactCanvas.gameObject.SetActive(false);
            }
            item = null;
        }
        if (collision.CompareTag("Hide Spot") && hideSpot!= null)
        {
            hideSpot = null;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        stateMachine = gameObject.AddComponent<StateMachine>();
        body = GetComponent<Collider2D>();

        // Đặt trạng thái ban đầu là PlayerIdleDownState
        stateMachine.ChangeState(new PlayerIdleDownState(gameObject, stateMachine, animator, outfitAnimator));
    }

    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            if (puzzle != null)
            {
                puzzle.OpenPuzzle();
            }
            if (hideSpot != null)
            {
                Hide(hideSpot);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (puzzle != null)
            {
                puzzle.ClosePuzzle();
            }
            if (hiding)
            {
                GetOut();
            }
        }
    }
    void Move()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Di chuyển nhân vật
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        // Chỉnh hitbox detect đối tượng
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Tính toán góc theo hướng di chuyển
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;

            // Xoay hitbox theo góc đã tính
            interactArea.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public void Hide(HideSpot hidePos)
    {
        body.enabled = false;
        spriteRenderer.enabled = false;
        outfit.enabled = false;
        canMove = false;
        transform.position = hidePos.transform.position;
        hiding = true;
    }
    public void GetOut()
    {
        body.enabled = true;
        spriteRenderer.enabled = true;
        outfit.enabled = true;
        canMove = true;
        hiding = false;
    }
}
