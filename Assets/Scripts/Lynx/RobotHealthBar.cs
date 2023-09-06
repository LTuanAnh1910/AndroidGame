using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currHealth;
    private float maxHealth = 30f;
    public RobotEnemy robot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currHealth = robot.startHealth;
        healthBar.fillAmount = currHealth / maxHealth;
    }
}
