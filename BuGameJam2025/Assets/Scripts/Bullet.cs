using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 5;
    [SerializeField] private float bulletLifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        //compare tag, if collision tag is minion, reduce minions health
        if (other.gameObject.CompareTag("Minion"))
        {
            MinionsController minion = other.gameObject.GetComponent<MinionsController>();
            if (minion != null)
            {
                minion.TakeDamage(bulletDamage); 
                Destroy(gameObject);
                Debug.Log("hit");
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
