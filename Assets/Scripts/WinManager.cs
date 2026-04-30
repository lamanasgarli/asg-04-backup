using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    public GameObject winPanel;
    public TMP_Text finalTimeText;
    public GameTimer gameTimer;

    public LeaderboardManager leaderboardManager; // NEW

    public void Win()
    {
        Time.timeScale = 0f;

        float time = gameTimer.GetFinalTime();

        finalTimeText.text = "Final Time: " + FormatTime(time);

        leaderboardManager.AddTime(time); // NEW

        winPanel.SetActive(true);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}