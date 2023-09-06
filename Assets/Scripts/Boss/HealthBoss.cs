using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HealthBoss : MonoBehaviour
{
    public static Action<BossEnemy> OnBossKilled;
    public static Action<BossEnemy> OnBossHit;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    private float initialHealth = 50f;
    private float maxHealth = 50f;

    public AudioSource audio;
    float time = 0;

    public float CurrentHealth { get; set; }
    private Image healthBar;
    private BossEnemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
        
        enemy = GetComponent<BossEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, CurrentHealth/maxHealth, Time.deltaTime * 10f);
    }

    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        BossHealthBar bhb = newBar.GetComponent<BossHealthBar>();
        healthBar = bhb.FillAmountImage;
    }

    public void DealDamage(float damage)
    {
		CurrentHealth = CurrentHealth - damage;
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            audio.Play();
            Die();
            initialHealth += 10f;
            maxHealth += 10f;
        }
        else
        {
            OnBossHit?.Invoke(enemy);
        }
    }

    private void Die()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Player.Gold += 100;
            Destroy(gameObject);
        }
        if (CurrentHealth == 0)
        {
            audio.Play();
            time = 2;
        }
    }

    internal void ResetHealth()
    {
        CurrentHealth = 0;
    }
}
