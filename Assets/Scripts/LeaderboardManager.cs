using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text leaderboardText;

    private const int MaxScores = 5;
    private const string KeyPrefix = "BestTime_";

    public void AddTime(float newTime)
    {
        List<float> times = LoadTimes();
        times.Add(newTime);
        times.Sort();

        if (times.Count > MaxScores)
            times = times.GetRange(0, MaxScores);

        for (int i = 0; i < times.Count; i++)
            PlayerPrefs.SetFloat(KeyPrefix + i, times[i]);

        PlayerPrefs.SetInt("SavedTimeCount", times.Count);
        PlayerPrefs.Save();

        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        List<float> times = LoadTimes();

        string text = "TOP 5 TIMES\n\n";

        for (int i = 0; i < MaxScores; i++)
        {
            if (i < times.Count)
                text += $"{i + 1}. {FormatTime(times[i])}\n";
            else
                text += $"{i + 1}. --:--\n";
        }

        leaderboardText.text = text;
    }

    private List<float> LoadTimes()
    {
        List<float> times = new List<float>();
        int count = PlayerPrefs.GetInt("SavedTimeCount", 0);

        for (int i = 0; i < count; i++)
            times.Add(PlayerPrefs.GetFloat(KeyPrefix + i));

        times.Sort();
        return times;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}