using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsAttack : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;
    [SerializeField] public GameObject player;
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

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.Log("No plyerController Found");
            }
        }
        if (playerController == null)
        {
            playerController = player.GetComponent<PlayerController>();
            if (playerController == null)
            {
                Debug.Log("PCon not found");
            }
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
            playerController.playerHealth -= attackDamage;
            playerController.playerHealth = Mathf.Clamp(playerController.playerHealth, 0, playerController.maxHealth); //clamping the playerHealth so it cannot be negative
            Debug.Log($"Player health: {playerController.playerHealth}"); //changed the debug statement to use interpolation
            attackTimer = 0f;
        }
    }
}