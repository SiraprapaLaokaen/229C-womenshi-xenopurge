using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
 
    public void TakeDamage( int damage )
    {
        health -= damage;
 
        if ( health <= 0 )
        {
            Die();
        }
 
    }//TakeDamage

    void Die()
    {
        if (gameObject.name == "alienboss")
        {
            BossManager.instance.BossKilled();

            WinManager winManager = FindObjectOfType<WinManager>();
            if (winManager != null)
            {
                winManager.BossKilled();
            }
        }
        else
        {
            EnemyManager.instance.EnemyKilled();
            
            WinManager winManager = FindObjectOfType<WinManager>();
            if (winManager != null)
            {
                winManager.EnemyKilled();
            }
        }

        Destroy(gameObject);
    }
}
