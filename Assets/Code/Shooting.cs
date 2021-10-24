using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer = 0.3f;
    public float bulletForce = 20f;
    private Transform target;

    public void Shoot(Transform target)
    {
        this.target = target;
        Invoke("Commit", timer);
    }

    public void Commit()
    {
        if (target != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.VelocityChange);
        }
    }
}