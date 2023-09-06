using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LizardHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currHealth;
    private float maxHealth = 15f;
    public LizardEnemy lizard;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currHealth = lizard.startHealth;
        healthBar.fillAmount = currHealth / maxHealth;
    }
}
