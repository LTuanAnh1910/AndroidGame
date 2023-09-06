using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TestGame : MonoBehaviour
{
    // Start is called before the first frame update
    public float count = 0;
    public GameOver1 gameover;
    public Scoro a;
    public int i = 0;
    public GameController GC;
    void Start()
    {
        GC = FindObjectOfType<GameController>();
        if (a.Value == true)
        {
            Player.Heart = PlayerPrefs.GetInt("Health");
            Player.Wave = PlayerPrefs.GetInt("Wave");
            gameObject.GetComponent<Player>().TimeInGame = PlayerPrefs.GetFloat("Time");
            Player.Gold = PlayerPrefs.GetInt("Gold");
            gameObject.GetComponent<Player>().Load();
            a.setValue(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;
    }
    public void Saving()
    {

        PlayerPrefs.SetInt("Health", Player.Heart);
        PlayerPrefs.SetInt("Wave", Player.Wave);
        PlayerPrefs.SetFloat("Time", gameObject.GetComponent<Player>().TimeInGame);
        PlayerPrefs.SetInt("Gold", Player.Gold);
        a.NumTuret = 0;
        foreach (GameObject g in GC.ListTurret)
        {
            if (g.tag == "Normal")
            {
                PlayerPrefs.SetFloat("X" + a.NumTuret, g.transform.position.x);
                PlayerPrefs.SetFloat("Y" + a.NumTuret, g.transform.position.y);
                PlayerPrefs.SetInt("Level" + a.NumTuret, g.GetComponent<NormalGun>().Level);
                PlayerPrefs.SetInt("Atk" + a.NumTuret, g.GetComponent<NormalGun>().Atk);
                PlayerPrefs.SetInt("Range" + a.NumTuret, g.GetComponent<NormalGun>().Range);
                PlayerPrefs.SetInt("Gold" + a.NumTuret, g.GetComponent<NormalGun>().Gold);
                PlayerPrefs.SetFloat("Reload" + a.NumTuret, g.GetComponent<NormalGun>().Reload);
                PlayerPrefs.SetInt("upgradeGold" + a.NumTuret, g.GetComponent<NormalGun>().upgradeGold);
                PlayerPrefs.SetInt("sellGold" + a.NumTuret, g.GetComponent<NormalGun>().sellGold);
                PlayerPrefs.SetInt("Type" + a.NumTuret, 0);
            }
            if (g.tag == "Explosion")
            {
                PlayerPrefs.SetFloat("X" + a.NumTuret, g.transform.position.x);
                PlayerPrefs.SetFloat("Y" + a.NumTuret, g.transform.position.y);
                PlayerPrefs.SetInt("Level" + a.NumTuret, g.GetComponent<ExplosionGun>().Level);
                PlayerPrefs.SetInt("Atk" + a.NumTuret, g.GetComponent<ExplosionGun>().Atk);
                PlayerPrefs.SetInt("Range" + a.NumTuret, g.GetComponent<ExplosionGun>().Range);
                PlayerPrefs.SetInt("Gold" + a.NumTuret, g.GetComponent<ExplosionGun>().Gold);
                PlayerPrefs.SetFloat("Reload" + a.NumTuret, g.GetComponent<ExplosionGun>().Reload);
                PlayerPrefs.SetInt("upgradeGold" + a.NumTuret, g.GetComponent<ExplosionGun>().upgradeGold);
                PlayerPrefs.SetInt("sellGold" + a.NumTuret, g.GetComponent<ExplosionGun>().sellGold);
                PlayerPrefs.SetInt("Type" + a.NumTuret, 1);
            }
            a.setNum(1);
        }
        SceneManager.LoadScene("Start");



    }
}
