using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : Puzzle
{
    Animator animator;
    [SerializeField] bool correctPassword = false;
    [SerializeField] List<int> password;
    [SerializeField] List<int> currentNumbers = new List<int> { 0, 0, 0, 0 };
    [SerializeField] List<Button> buttons;
    List<Text> buttonTexts;
    void Start()
    {
        animator = GetComponent<Animator>();

        buttonTexts = new List<Text>();
        foreach (var button in buttons)
        {
            Text text = button.GetComponentInChildren<Text>();
            buttonTexts.Add(text);
        }
    }

    public void Check()
    {
        if (password.Count != buttons.Count)
        {
            Debug.Log("So luong nut khong bang so luong so trong mat khau");
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            if (currentNumbers[i] == password[i])
            {
                if (i == buttons.Count - 1)
                {
                    correctPassword = true;
                }
                continue;
            }
            else
            {
                correctPassword = false;
                break;
            }
        }
    }

    public void IncreaseNumber(int i)
    {
        if (i >= buttons.Count)
        {
            Debug.Log("Index khong hop le");
        }

        currentNumbers[i]++;
        if (currentNumbers[i] > 9) currentNumbers[i] = 0;
        buttonTexts[i].text = currentNumbers[i].ToString();

        Check();
    }

    public void OpenSafe()
    {
        if (!correctPassword)
        {
            animator.Play("TryOpen");
        }
        else
        {
            animator.Play("Open");
        }
    }
}
