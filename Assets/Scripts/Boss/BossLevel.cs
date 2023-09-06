using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : MonoBehaviour
{
    [SerializeField] private int lives = 10;

    public int TotalLives { get; set; }
    public int CurrentWave { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        TotalLives = lives;
        CurrentWave = 1;
    }

    private void ReduceLives(BossEnemy be)
    {
        TotalLives--;
        if(TotalLives <= 0)
        {
            TotalLives = 0;
            GameOver();
        }


    }

    private void GameOver()
    {
        
    }
}
