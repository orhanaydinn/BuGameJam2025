using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsAttack : MonoBehaviour
{
    private float attackTimer;
    [SerializeField] private float attackInterval = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval)
            {
                PlayerController.playerHealth -= 1;
                Debug.Log("Player attacked by minion!");
                Debug.Log("Player health: " + PlayerController.playerHealth);
                attackTimer = 0f;
            }

        }
    }
}
