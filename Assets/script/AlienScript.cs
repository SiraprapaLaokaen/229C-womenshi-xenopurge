using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public GameObject Target;
   /* public Transform player;
    public float speed = 3f;
    private Rigidbody rb; */

    public Transform player;
    public float speed = 3f;
    public float detectionRange = 10f; 
    private Rigidbody rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Target.gameObject.transform);

    }
 
    /*void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }*/

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange) // ตรวจสอบระยะ
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // ป้องกันศัตรูลอยขึ้น

            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
