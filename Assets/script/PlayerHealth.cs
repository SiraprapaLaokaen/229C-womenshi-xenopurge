using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject deathUI; // UI ข้อความ "ตายแล้ว"
    public Button restartButton; // ปุ่ม Restart

    void Start()
    {
        currentHealth = maxHealth;
        deathUI.SetActive(false);
        restartButton.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame); // ตั้งให้ปุ่ม Restart ใช้งานได้
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        deathUI.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0; // หยุดเกม
    }

    void RestartGame()
    {
        Time.timeScale = 1; // ทำให้เกมกลับมาปกติ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลดซีนใหม่
    }
}
