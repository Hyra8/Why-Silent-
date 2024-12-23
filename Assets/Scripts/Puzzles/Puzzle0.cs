using UnityEngine;
using UnityEngine.UI;

public class Puzzle0 : Puzzle
{
    public GameObject puzzle;

    [Header("Others")]
    [SerializeField] Text answer;
    public override void OpenPuzzle()
    {
        MainCamera.instance.ChangeTarget(puzzle.gameObject);
        //base.OpenPuzzle();
    }

    public void CheckAnswer()
    {
        if (answer.text == "2")
        {
            Debug.Log("Puzzle0 solved!");
            isSolved = true;
        }
        else
        {
            Debug.Log("Wrong answer!");
        }
    }
}
