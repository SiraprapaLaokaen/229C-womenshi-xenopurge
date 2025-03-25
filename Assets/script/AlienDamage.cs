using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDamage : MonoBehaviour
{
    public int damage = 10;
    private bool hasAttacked = false; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "soilder" && !hasAttacked) 
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); 
                hasAttacked = true; 
                Debug.Log("soilder โดนโจมตี! เลือดลด " + damage);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "soilder")
        {
            hasAttacked = false; 
        }
    }


}

    



