using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLevel1 : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;

    void Start()
    {
        // Assign button click events
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}