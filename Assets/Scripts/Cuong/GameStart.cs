using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Scoro a; 
    public void Startgame()
    {
        a.setValue(false);
        PlayerPrefs.DeleteAll();
        a.NumTuret = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Scene");

    }
    public void Resumeaaa()
    {
        a.setValue( true);
        SceneManager.LoadScene("Game Scene");

    }
    public void quitGame()
    {
        Application.Quit(); 
    }
}
