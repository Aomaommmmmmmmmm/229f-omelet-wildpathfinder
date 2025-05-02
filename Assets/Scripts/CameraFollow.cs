using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // อ้างอิงถึง Transform ของตัวละคร
    public float smoothSpeed = 0.125f; // ความเร็วในการเลื่อนกล้อง (ยิ่งน้อยยิ่งนุ่มนวล)
    public Vector3 offset; // ระยะห่างระหว่างกล้องและตัวละคร
    public float minX = 0f; // ขอบซ้ายของกล้อง (ปรับตามฉาก)

    void LateUpdate()
    {
        // คำนวณตำแหน่งที่ต้องการให้กล้องไป
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        
        // ทำให้กล้องเลื่อนอย่างนุ่มนวลไปยังตำแหน่งที่ต้องการ
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // จำกัดขอบซ้ายของกล้อง
        smoothedPosition.x = Mathf.Max(smoothedPosition.x, minX);
        
        // อัปเดตตำแหน่งกล้อง
        transform.position = smoothedPosition;
    }
}