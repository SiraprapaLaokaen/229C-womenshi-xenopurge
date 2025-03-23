using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{

    public GameObject Target;
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 10f;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange) // ถ้าผู้เล่นอยู่ในระยะตรวจจับ
        {
            transform.LookAt(Target.transform); // ให้ศัตรูหันไปทางผู้เล่น
        }
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange) 
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // ป้องกันศัตรูลอยขึ้น

            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

            animator.SetBool("isWalking", true); // เปลี่ยนเป็นอนิเมชั่นเดิน
        }
        else
        {
            animator.SetBool("isWalking", false); // เปลี่ยนเป็นอนิเมชั่นอยู่เฉยๆ
        }
    }
}
