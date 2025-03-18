using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
   public CharacterController controller;
    public Transform playerCamera;
 
    public float walkSpeed = 5f;
    public float jumpHeight = 2f;  // ความสูงในการกระโดด
    public float gravity = -9.81f; // แรงโน้มถ่วง
 
    public float mouseSensitivity = 100f;
 
    private float xRotation = 0f;
    private Vector3 velocity;
 
    private bool isGrounded;
 
    void Update()
    {
        // ตรวจสอบว่าตัวละครยืนอยู่บนพื้นหรือไม่
        isGrounded = controller.isGrounded;
 
        // รับค่าการหมุนกล้องด้วยเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
        // ควบคุมการหมุนกล้องขึ้น-ลง
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // จำกัดมุมมองไม่ให้กล้องหงายหรือก้มเกินไป
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
 
        // หมุนตัวละครซ้าย-ขวา
        transform.Rotate(Vector3.up * mouseX);
 
        // รับค่าการเคลื่อนที่
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
 
        // กำหนดทิศทางการเคลื่อนที่
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * walkSpeed * Time.deltaTime);
 
        // กระโดด
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // คำนวณแรงกระโดด
        }
 
        // ใช้แรงโน้มถ่วง
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
