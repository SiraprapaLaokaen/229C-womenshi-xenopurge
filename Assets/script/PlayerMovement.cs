using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    
    private Vector3 velocity;
 
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  // A, D หรือ ลูกศรซ้ายขวา
        float moveZ = Input.GetAxis("Vertical");    // W, S หรือ ลูกศรขึ้นลง
 
        Vector3 move = transform.right * moveX + transform.forward * moveZ;  
        controller.Move(move * speed * Time.deltaTime);
 
        // ใช้แรงโน้มถ่วง
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
