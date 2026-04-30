using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject winPanel;
    public TMP_Text finalTimeText;
    public GameTimer gameTimer;

    private bool hasWon = false;

    public void Win()
    {
        if (hasWon) return;

        hasWon = true;

        Time.timeScale = 0f;

        float time = gameTimer.GetFinalTime();
        finalTimeText.text = "Final Time: " + FormatTime(time);

        winPanel.SetActive(true);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}