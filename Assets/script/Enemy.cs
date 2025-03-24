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
        /*EnemyManager.instance.EnemyKilled(); // แจ้งให้ EnemyManager นับว่าศัตรูถูกฆ่า
        Destroy(gameObject);*/

        if (gameObject.name == "alienboss") // เช็คว่าศัตรูเป็น "alienboss"
        {
            BossManager.instance.BossKilled(); // ส่งไปที่ BossManager
        }
        else
        {
            EnemyManager.instance.EnemyKilled(); // ส่งไปที่ EnemyManager
        }

        Destroy(gameObject);
    }
}
