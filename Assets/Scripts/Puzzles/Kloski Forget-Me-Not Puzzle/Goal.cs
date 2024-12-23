using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private MoveTheBlockPuzzle puzzle;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Keybox"))
        {
            puzzle.switchState();
            puzzle.Solve();
        }
    }
}
