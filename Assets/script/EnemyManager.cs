using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; 
    public Text enemyCountText; // UI แสดงจำนวนศัตรูที่ถูกฆ่า
    private int enemiesKilled = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateEnemyUI();
    }

    void UpdateEnemyUI()
    {
         enemyCountText.text = "Kill Alien " + enemiesKilled + " / 12";
    }
}
