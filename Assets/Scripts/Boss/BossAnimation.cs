using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    //public GameObject death;
    private Animator animator;
    private BossEnemy bossEnemy;
    private HealthBoss bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossEnemy= GetComponent<BossEnemy>();
        bossHealth = GetComponent<HealthBoss>();
    }

    // Update is called once per frame
    private void PlayHurtAnimation()
    {
        animator.SetTrigger("boss_hurt");
    }

    private float GetCurrnetAnimationLenght()
    {
        float animationLenght = animator.GetCurrentAnimatorStateInfo(0).length;
        return animationLenght;
    }

    private IEnumerator PlayHurt()
    {
        //bossEnemy.StopMovement();
        PlayHurtAnimation();
        yield return new WaitForSeconds(GetCurrnetAnimationLenght() + 0.3f);
        //bossEnemy.ResumeMovement();
    }

    private IEnumerator PlayDead()
    {
        //bossEnemy.StopMovement();
        //Instantiate(death, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        //bossEnemy.ResumeMovement();
        bossHealth.ResetHealth();
        //ObjectPooler.ReturnToPool(bossEnemy.gameObject);
    }

    private void BossHit(BossEnemy boss)
    {
        if(bossEnemy = boss)
        {
            StartCoroutine(PlayHurt());
        }
    }

    private void BossDead(BossEnemy boss)
    {
        if (bossEnemy = boss)
        {
            StartCoroutine(PlayDead());
        }
    }

    private void OnEnable()
    {
        HealthBoss.OnBossHit += BossHit;
        HealthBoss.OnBossKilled += BossDead;
    }

    private void OnDisable()
    {
        HealthBoss.OnBossHit -= BossHit;
        HealthBoss.OnBossKilled -= BossDead;
    }
}
