using UnityEngine;

public class MoveTheBlockPuzzle : Puzzle
{
    [Header("Implemented")]

    [SerializeField] private GameObject blockPuzzle;

    [SerializeField] private GameObject root;

    [SerializeField] private Canvas getKeyCanvas;

    private float lastCameraSize;

    private void Awake()
    {
        lastCameraSize = Camera.main.orthographicSize;
    }

    public override void OpenPuzzle()
    {
        root.SetActive(true);
        MainCamera.instance.ChangeTarget(blockPuzzle);
        Player.instance.canMove = false;
        lastCameraSize = Camera.main.orthographicSize;
        Camera.main.orthographicSize = 5.0f;
    }

    public override void ClosePuzzle()
    {
        MainCamera.instance.ChangeTarget(Player.instance.gameObject);
        root.SetActive(false);
        Player.instance.canMove = true;
        Camera.main.orthographicSize = 3.0f;
    }

    // Start is called before the first frame update



    /// <summary>
    /// Hành động khi hoàn thành Puzzle
    /// </summary>
    public void switchState()
    {
        Camera.main.orthographicSize = 3.0f;
        getKeyCanvas.gameObject.SetActive(true);
        blockPuzzle.SetActive(false);
    }

}
