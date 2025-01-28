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
    private void OnCollisionEnter(Collision collision)
    {
        //compare tag, if collision tag is minion, reduce minions health
        if (collision.gameObject.CompareTag("Minion"))
        {
            Debug.Log("hit");
            MinionsController minion = collision.gameObject.GetComponent<MinionsController>();
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
