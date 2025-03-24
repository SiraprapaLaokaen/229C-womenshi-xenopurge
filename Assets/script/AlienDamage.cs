using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDamage : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soilder") // ตรวจสอบว่าชนกับ Soilder หรือไม่
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // ลดเลือดของผู้เล่น
                Debug.Log("soilder โดนโจมตี! เลือดลด " + damage);
            }
        }
    }

}

    



