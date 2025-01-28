using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        Debug.Log(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            HandlePlayerDeath();
        }
    }

    void HandlePlayerDeath()
    {
        Debug.Log("Game Over");
    }
    //Changes: I moved the debug statement into its own method so we can call it instead of having all the death logic in the update function
}