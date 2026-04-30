using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float elapsedTime;
    private bool timerRunning = true;

    void Update()
    {
        if (!timerRunning) return;

        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public float GetFinalTime()
    {
        return elapsedTime;
    }
}