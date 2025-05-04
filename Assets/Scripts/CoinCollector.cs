using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public int coinsCollected = 0;
    public int totalCoins = 3;

    public TextMeshProUGUI coinText; // TMP Text สำหรับแสดง 1 / 3
    public GameObject winPanel; // ลาก UI Win Panel มาใส่ใน Inspector

    void Start()
    {
        UpdateUI();

        if (winPanel != null)
        {
            winPanel.SetActive(false); // ซ่อนไว้ก่อน
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // เหรียญหายไป
            coinsCollected++;
            UpdateUI();

            if (coinsCollected >= totalCoins)
            {
                Debug.Log("You Win!");
                ShowWinPanel();
            }
        }
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = coinsCollected + " / " + totalCoins;
        }
    }

    void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; // หยุดเกมถ้าต้องการ
        }
    }
}