using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject buttonPanel;
    public GameObject titleText;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        buttonPanel.SetActive(false);
        titleText.SetActive(false);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        buttonPanel.SetActive(true);
        titleText.SetActive(true);
    }
}