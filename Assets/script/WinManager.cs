using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public int enemyKillCount = 0;
    public int bossKillCount = 0;
    public int totalEnemyRequired = 12;
    public int totalBossRequired = 1;

    public GameObject winUI; // UI ชนะเกม
    public Button mainMenuButton; // ปุ่มกลับเมนูหลัก

    void Start()
    {
        winUI.SetActive(false); // ปิด UI ชนะตอนเริ่มเกม
        mainMenuButton.gameObject.SetActive(false);

        mainMenuButton.onClick.AddListener(ReturnToMainMenu); // ให้ปุ่มทำงานเมื่อกด
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        CheckWinCondition();
    }

    public void BossKilled()
    {
        bossKillCount++;
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (enemyKillCount >= totalEnemyRequired && bossKillCount >= totalBossRequired)
        {
            winUI.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            Time.timeScale = 0; // หยุดเกมเมื่อชนะ
        }
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1; // ทำให้เกมกลับมาปกติ
        SceneManager.LoadScene("MainMenu"); // โหลดเมนูหลัก
    }
}

