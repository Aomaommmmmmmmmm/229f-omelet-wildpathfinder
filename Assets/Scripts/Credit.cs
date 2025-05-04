using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public float creditsDuration = 3f;

    void Start()
    {
       
        Invoke("LoadMainMenu", creditsDuration);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // ใช้ชื่อ Scene จริงของคุณ
    }
}
