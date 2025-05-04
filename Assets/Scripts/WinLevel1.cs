using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLevel1 : MonoBehaviour
{
    public Button mainMenuButton;
    public Button NextLevel2Button;

    void Start()
    {
        // Assign button click events
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        NextLevel2Button.onClick.AddListener(GoToLevel2);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void GoToLevel2()
    {
        SceneManager.LoadScene("Test level1");
    }
}