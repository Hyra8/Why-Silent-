using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MazePuzzle : Puzzle
{
    [Header("Implemented")]
    public float rotationSpeed; // Tốc độ xoay của mê cung
    private Button button;

    [SerializeField] private Image painting;
    [SerializeField] private Image table;


    private bool isPuzzleFinish = false;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public override void OpenPuzzle()
    {
        defaultCanvas.gameObject.SetActive(true);
        MainCamera.instance.ChangeTarget(defaultCanvas.gameObject);
        Player.instance.canMove = false;
    }

    public override void ClosePuzzle()
    {
        MainCamera.instance.ChangeTarget(Player.instance.gameObject);
        defaultCanvas.gameObject.SetActive(false);
        Player.instance.canMove = true;
    }

    public void SwitchState()
    {
        painting.gameObject.SetActive(false);
        table.gameObject.SetActive(true);
    }
}
