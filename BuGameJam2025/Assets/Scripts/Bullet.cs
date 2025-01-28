using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //compare tag, if collision tag is minion, reduce minions health

        Destroy(gameObject);
    }
}
