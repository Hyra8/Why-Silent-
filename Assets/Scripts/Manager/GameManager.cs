using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public byte GameState = 0; // 0-playing / 1-paused
    public GameObject PauseCanvas;
    public GameObject SettingsCanvas;

    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (GameState == 0)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {
        PauseCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        Time.timeScale = 1;
        GameState = 0;
    }
    public void Pause()
    {
        PauseCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        Time.timeScale = 0;
        GameState = 1;
    }
    public void Settings()
    {
        PauseCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Player.instance.canMove = false;
        ActivateAndFadeIn(GameOverCanvas);
    }

    [SerializeField] private CanvasGroup GameOverCanvas; // CanvasGroup cần fade
    [SerializeField] private float fadeDuration = 1.0f; // Thời gian thực hiện fade

    // Hàm kích hoạt và fade canvas
    public void ActivateAndFadeIn(CanvasGroup canvasGroup)
    {
        GameOverCanvas = canvasGroup;
        GameOverCanvas.gameObject.SetActive(true); // Bật Canvas
        StartCoroutine(FadeCanvas(0f, 1f)); // Từ alpha = 0 đến alpha = 1
    }

    // Coroutine thực hiện hiệu ứng fade
    private System.Collections.IEnumerator FadeCanvas(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        GameOverCanvas.alpha = startAlpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            GameOverCanvas.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        GameOverCanvas.alpha = endAlpha;
    }
}
