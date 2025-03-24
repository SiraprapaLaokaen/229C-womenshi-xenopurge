using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // ใช้ TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth; 

    public GameObject deathUI; 
    public Button restartButton; 

    public TextMeshProUGUI healthText; 

    void Start()
    {
        currentHealth = maxHealth;
        deathUI.SetActive(false);
        restartButton.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame); 

        UpdateHealthUI(); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

        UpdateHealthUI(); 

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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateHealthUI()
    {
        healthText.text = "HP " + currentHealth + " / " + maxHealth;
    }
}
