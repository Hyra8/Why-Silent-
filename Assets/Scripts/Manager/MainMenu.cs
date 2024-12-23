using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] Text gameNameText;

    [SerializeField] Text labelText;
    [SerializeField] Text instructionText;
    [SerializeField] GameObject InstructionButtons;
    private void Start()
    {
        Time.timeScale = 1.0f;
        audioManager.PlayMusic("Menu Theme");
    }

    public void LoadMainMenu()
    {
        labelText.enabled = false;
        instructionText.enabled = false;
        InstructionButtons.SetActive(false);

        mainMenuButtons.SetActive(true);
        gameNameText.enabled = true;
    }

    public void LoadInstruction()
    {
        labelText.enabled = true;
        instructionText.enabled = true;
        InstructionButtons.SetActive(true);

        mainMenuButtons.SetActive(false);
        gameNameText.enabled = false;
    }

    public void PlayGame()
    {
        audioManager.StopMusic("Menu Theme");
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
