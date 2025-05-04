using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coinsCollected = 0;
    public int totalCoins = 3;

    public Text coinText; // drag UI Text here in Inspector

    void Start()
    {
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // ทำให้เหรียญหายไป
            coinsCollected++;
            UpdateUI();

            if (coinsCollected >= totalCoins)
            {
                Debug.Log("You Win!");
                // ใส่เหตุการณ์ที่เกิดขึ้นเมื่อเก็บครบ เช่น ขึ้นฉากใหม่
            }
        }
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinsCollected + " / " + totalCoins;
        }
    }
}
