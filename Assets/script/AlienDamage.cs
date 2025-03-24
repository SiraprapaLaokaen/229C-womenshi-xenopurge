using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDamage : MonoBehaviour
{
    public int damage = 10;
    private bool canAttack = true; // ควบคุมการโจมตีซ้ำ

    void OnTriggerEnter(Collider other)
    {
        if (canAttack && other.gameObject.name == "soilder") // ตรวจสอบว่าชนกับ Soilder หรือไม่
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // ลดเลือดของผู้เล่น
                Debug.Log("soilder โดนโจมตี! เลือดลด " + damage);
                canAttack = false; // ล็อกไม่ให้โจมตีซ้ำ
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "soilder")
        {
            canAttack = true; // ปลดล็อกให้โจมตีได้ใหม่
        }
    }

}

    



