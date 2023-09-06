using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float TimeInGame;
    public Text TimeText;

    public float CountTime;

    public int WaveInGame;
    public static int Wave;
    public Text WaveText;

    public static int Heart;
    public int HeartInGame;
    public Text HeartText;

    public static int Gold;
    public int GoldInGame;
    public Text GoldText;


    private bool isPause = false;
    public static Player player;

    public GameOver1 gameover;
    public GameObject normal;
    public GameObject explo;
    public GameController GC;
    public Scoro a;
    void Start()
    {
        Heart = HeartInGame;
        Gold = GoldInGame;
        Wave= WaveInGame;
        GC = FindObjectOfType<GameController>();
        TimeInGame = 0f;
        CountTime = 0f;
    }

    void Update()
    {
        TimeInGame += Time.deltaTime;
        CountTime += Time.deltaTime;

        //if (CountTime >= 10f)
        //{
        //    CountTime = 0f;
            
        //}

        //countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        HeartText.text = string.Format("Heart: " + Heart);
        GoldText.text = string.Format("Gold: " + Gold);
        WaveText.text = string.Format("Wave: " + Wave);
        TimeText.text = string.Format("Time: {00:00.00}", TimeInGame);


        if (Heart <= 0)
        {
            GameOver();
        }
    }

    void PauseGame()
    {
        if(!isPause)
        {
            isPause = true;
            TimeInGame = Time.deltaTime;
            TimeInGame = Time.timeScale;

        }
    }

    public void TimeIncrease()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
        }
        else if (Time.timeScale == 2)
        {
            Time.timeScale = 4;
        }
        else if (Time.timeScale == 4)
        {
            Time.timeScale = 1;
        }
    }
    public void GameOver()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        gameover.setup();
    }

    public void Load()
    {

        for (int i = 0  ;i <a.NumTuret; i++)
        {
            Spawn(i);
            Debug.Log(a.NumTuret+"abc");
         }

    }

    private void Spawn(int s)
    {
        float x = PlayerPrefs.GetFloat("X" + s);
        float y = PlayerPrefs.GetFloat("Y" + s);
        int Level = PlayerPrefs.GetInt("Level" + s);
        Debug.Log(Level);
        int Atk = PlayerPrefs.GetInt("Atk" + s);
        int Range = PlayerPrefs.GetInt("Range" + s);
        int Gold = PlayerPrefs.GetInt("Gold" + s);
        float Reload = PlayerPrefs.GetFloat("Reload" + s);
        int upgradeGold = PlayerPrefs.GetInt("upgradeGold" + s);
        int sellGold = PlayerPrefs.GetInt("sellGold" + s);
        Vector2 pos = new Vector2(x, y);
        //  int Level = PlayerPrefs.GetInt("Level" + s);
        int type = PlayerPrefs.GetInt("Type" + s);
        if (type == 0)
        {
            normal.GetComponent<NormalGun>().Level = Level;
            normal.GetComponent<NormalGun>().Atk = Atk;
            normal.GetComponent<NormalGun>().Range = Range;
            normal.GetComponent<NormalGun>().Gold = Gold;
            normal.GetComponent<NormalGun>().Reload = Reload;
            normal.GetComponent<NormalGun>().upgradeGold = upgradeGold;
            normal.GetComponent<NormalGun>().sellGold = sellGold;
            GameObject sq = Instantiate(normal, pos, Quaternion.identity);
            GC.ListTurret.Add(sq);




        }
        if (type == 1)

        {
            explo.GetComponent<ExplosionGun>().Level = Level;
            explo.GetComponent<ExplosionGun>().Atk = Atk;
            explo.GetComponent<ExplosionGun>().Range = Range;
            explo.GetComponent<ExplosionGun>().Gold = Gold;
            explo.GetComponent<ExplosionGun>().Reload = Reload;
            explo.GetComponent<ExplosionGun>().upgradeGold = upgradeGold;
            explo.GetComponent<ExplosionGun>().sellGold = sellGold;
            GameObject sq = Instantiate(explo, pos, Quaternion.identity);
            GC.ListTurret.Add(sq);


        }


    }

    public void Awake()
    {
        player = this;
    }
}
