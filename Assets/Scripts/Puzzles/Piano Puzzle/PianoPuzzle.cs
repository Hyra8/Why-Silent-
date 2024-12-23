using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoPuzzle : Puzzle
{
    [SerializeField] Button getKeyButton;

    [Header("Cấu hình Puzzle")]
    public List<string> correctSequence; // Chuỗi nốt đúng (ví dụ: ["C", "E", "G"])
    public int currentIndex = 0; // Chỉ số hiện tại trong chuỗi
    public Animator keyAnimator;
    bool needCheck = true;

    private void Start()
    {
        getKeyButton.gameObject.SetActive(false);
    }

    // Hàm được gọi khi một phím piano được bấm
    public void OnPianoKeyPress(string key)
    {
        // Kiểm tra xem phím bấm có đúng không
        if (needCheck && key == correctSequence[currentIndex])
        {
            currentIndex++; // Chuyển sang nốt tiếp theo

            // Nếu hoàn thành chuỗi
            if (currentIndex >= correctSequence.Count)
            {
                PuzzleCompleted();
            }
        }
        else
        {
            ResetPuzzle();
            if (needCheck && key == correctSequence[currentIndex])
            {
                currentIndex++; // Chuyển sang nốt tiếp theo

                // Nếu hoàn thành chuỗi
                if (currentIndex >= correctSequence.Count)
                {
                    PuzzleCompleted();
                }
            }
        }
    }

    // Khi hoàn thành puzzle
    private void PuzzleCompleted()
    {
        needCheck = false;
        getKeyButton.gameObject.SetActive(true);
        keyAnimator.Play("GetKeyButton");
    }

    // Reset chuỗi về trạng thái ban đầu
    private void ResetPuzzle()
    {
        currentIndex = 0;
    }
}