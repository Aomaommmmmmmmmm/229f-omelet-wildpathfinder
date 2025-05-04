using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLevel2 : MonoBehaviour
{
    public Button mainMenuButton;
    public Button CreditButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        CreditButton.onClick.AddListener(Credit);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    void Credit()
    {
        SceneManager.LoadScene("UI Credit");
        Time.timeScale = 1f;
    }
}