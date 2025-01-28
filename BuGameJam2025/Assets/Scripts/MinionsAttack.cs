using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsAttack : MonoBehaviour
{
    private float attackTimer;
    [SerializeField] private float attackInterval = 5f;
    [SerializeField] private int attackDamage = 10;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Attack();
        }
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
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
}