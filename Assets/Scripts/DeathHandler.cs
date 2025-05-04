using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    // Call this method when the player dies
    public void OnPlayerDeath()
    {
        // Load GameOver scene immediately
        SceneManager.LoadScene("GameOver");
    }
}