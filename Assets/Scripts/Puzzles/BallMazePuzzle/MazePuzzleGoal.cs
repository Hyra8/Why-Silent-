using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzleGoal : MonoBehaviour
{
    [SerializeField] private MazePuzzle puzzle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ball"))
        {
            puzzle.SwitchState();
            puzzle.Solve();
        }
    }
}
