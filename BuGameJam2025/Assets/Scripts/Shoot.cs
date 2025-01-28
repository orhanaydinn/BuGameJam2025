using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private Transform firePointTransform;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] float fireRate = 0.5f;

    private float shootTimer;
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && shootTimer >= fireRate)
        {
            Fire();
            shootTimer = 0;
        }
    }

    private void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        firePointTransform = firePoint.GetComponent<Transform>();
    }

    public void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Bullet prefab or fire point is not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePointTransform.position, firePointTransform.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            //bulletRb.AddForce(firePointTransform.forward * bulletSpeed, ForceMode.Impulse);
            bulletRb.velocity = firePointTransform.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("The bullet prefab does not have a Rigidbody component!");
        }
    }
}
