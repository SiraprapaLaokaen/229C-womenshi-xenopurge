using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float lightShootForce = 10f; // ยิงเบา(คลิกซ้าย)
    public float heavyShootForce = 25f; // ยิงแรง(คลิกขวา)

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // คลิกซ้าย
        {
            Shoot(lightShootForce);
        }
        else if (Input.GetMouseButtonDown(1)) // คลิกขวา
        {
            Shoot(heavyShootForce);
        }
    }

    void Shoot(float force)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(firePoint.forward * force, ForceMode.Impulse); // F=ma
        }

        Destroy(bullet, 1f); 
    }
}
