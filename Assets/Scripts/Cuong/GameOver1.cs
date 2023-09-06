using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Scoro a;
    public void setup()
    {
        gameObject.SetActive(true);
    }
    public void restart()
    {
        PlayerPrefs.DeleteAll();
        a.NumTuret = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Scene");
    }
    public void menu()
    {
        SceneManager.LoadScene("Start");

    }
}
