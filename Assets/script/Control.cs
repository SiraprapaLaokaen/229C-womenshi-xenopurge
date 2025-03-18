using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerCamera; // กล้องหลัก (ติดที่หัวตัวละคร)
    
    public float speed = 5f;
    public float mouseSensitivity = 100f;
 
    private float xRotation = 0f;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ล็อคเมาส์ให้อยู่กลางจอ
    }
 
    void Update()
    {
        // รับค่าการเคลื่อนที่ของเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
        // ควบคุมการหมุนกล้องขึ้น-ลง
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // จำกัดมุมมองไม่ให้กล้องหงายหรือก้มเกินไป
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
 
        // หมุนตัวละครตามแนวนอน (ซ้าย-ขวา)
        transform.Rotate(Vector3.up * mouseX);
 
        // รับค่าการเคลื่อนที่ของตัวละคร
        float moveX = Input.GetAxis("Horizontal"); // A, D
        float moveZ = Input.GetAxis("Vertical");   // W, S
 
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);
    }
}
