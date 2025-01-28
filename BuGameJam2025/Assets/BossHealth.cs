using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] private float regenTimer;
    [SerializeField] private float timeUntilRegen;
    [SerializeField] private int regenAmount;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        regenTimer += Time.deltaTime;
        if (regenTimer >= timeUntilRegen)
        {
            RegenHealth();
        }
        //if purifier.raycast == true
        //Damage();
        if (currentHealth <= 0)
        {
            HandleBossDeath();
        }
        
    }

    void Damage()
    {
        //purifier.damage -= currentHealth;
    }

    void RegenHealth()
    {
        currentHealth += regenAmount;
    }

    void HandleBossDeath()
    {
        Debug.Log("Boss Defeated");
    }
}
