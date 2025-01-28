using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsController : MonoBehaviour
{
    private float attackTimer;
    [SerializeField] private float attackInterval = 5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int minionsHealth = 10;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (minionsHealth <= 0)
        {
            Die();
        }
    }
    void Attack()
    {

        if (attackTimer >= attackInterval)
        {
            PlayerController.playerHealth -= attackDamage;
            Debug.Log("Player health: " + PlayerController.playerHealth);
            attackTimer = 0f;
        }
    }

    public void TakeDamage(int damage)
    {
        minionsHealth -= damage;
        Debug.Log("Minion health: " + minionsHealth);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
