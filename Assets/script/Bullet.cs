using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ของกระสุน
    public Transform firePoint; // จุดยิงกระสุน
    public float lightShootForce = 10f; // แรงยิงเบา (คลิกซ้าย)
    public float heavyShootForce = 25f; // แรงยิงแรง (คลิกขวา)

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // คลิกซ้ายยิงเบา
        {
            Shoot(lightShootForce);
        }
        else if (Input.GetMouseButtonDown(1)) // คลิกขวายิงแรง
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
            rb.AddForce(firePoint.forward * force, ForceMode.Impulse); // ใช้ F = ma
        }

        Destroy(bullet, 1f); // ลบกระสุนหลัง 1 วินาที
    }
}
