using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [Header("Base")]
    public string puzzleName;
    public bool isSolved = false;
    protected Player player;
    public Canvas highlightCanvas;
    [SerializeField] public Canvas defaultCanvas;


    #region Singleton
    public static Puzzle instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        player = Player.instance;
    }
    public virtual void OnDropingItem()
    {

    }

    /// <summary>
    /// Tương tác với vật thể
    /// </summary>
    public virtual void OpenPuzzle()
    {
        DragObjectSystem.instance.openingPuzzle = this;
        defaultCanvas.gameObject.SetActive(true);
        MainCamera.instance.ChangeTarget(defaultCanvas.gameObject);
        Player.instance.canMove = false;
    }
    public virtual void ClosePuzzle()
    {
        DragObjectSystem.instance.openingPuzzle = null;
        MainCamera.instance.ChangeTarget(Player.instance.gameObject);
        defaultCanvas.gameObject.SetActive(false);
        Player.instance.canMove = true;
    }

    /// <summary>
    /// Hiển thị hộp văn bản
    /// </summary>
    public virtual void ShowTextBox()
    {
    }

    /// <summary>
    /// Các hành động sau khi giải được câu đố
    /// </summary>
    public void Solve()
    {
        isSolved = true;
    }
}

public class PuzzleController
{
    [Header("Base")]
    private Puzzle currentPuzzle;
    [SerializeField] protected Player player;

    public PuzzleController(Puzzle puzzle)
    {
        currentPuzzle = puzzle;
    }

    public void SwitchPuzzle(Puzzle puzzle)
    {
        currentPuzzle.gameObject.SetActive(false);
        currentPuzzle = puzzle;
        currentPuzzle.gameObject.SetActive(true);
    }

}