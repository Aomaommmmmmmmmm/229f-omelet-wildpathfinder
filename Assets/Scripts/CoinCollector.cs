using UnityEngine;
using TMPro; // เพิ่ม namespace สำหรับ TMP

public class CoinCollector : MonoBehaviour
{
    public int coinsCollected = 0;
    public int totalCoins = 3;

    public TextMeshProUGUI coinText; // ใช้ TMP แทน Text ปกติ

    void Start()
    {
        UpdateUI();
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
                // เพิ่มเหตุการณ์ต่อได้ เช่น เปลี่ยนฉาก หรือแสดงหน้าจอชัยชนะ
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
}