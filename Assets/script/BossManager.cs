using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public static BossManager instance; 
    public Text bossCountText; // UI แสดงจำนวนศัตรูที่ถูกฆ่า
    private int bossKilled = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void BossKilled()
    {
        bossKilled++;
        UpdateBossUI();
    }

    void UpdateBossUI()
    {
         bossCountText.text = "Kill Alien Boss " + bossKilled + " / 1";
    }
}
