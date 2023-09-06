using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currHealth;
    private float maxHealth = 10f;
    public AlienEnemy alien;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currHealth = alien.startHealth;
        healthBar.fillAmount = currHealth / maxHealth;
    }
}
