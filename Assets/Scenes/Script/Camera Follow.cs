using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // เครื่องบิน
    public Vector3 offset = new Vector3(0f, 3f, -8f); // ตำแหน่งกล้อง
    public float smoothSpeed = 5f;  // ความลื่น

    void LateUpdate()
    {
        if (target == null) return;

        // ตำแหน่งที่กล้องควรอยู่ (ตามหลังเครื่องบิน)
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // ทำให้กล้องเคลื่อนที่ลื่นๆ
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // ให้กล้องมองไปที่เครื่องบิน
        transform.LookAt(target);
    }
}