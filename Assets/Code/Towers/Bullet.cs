using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int DamageAmount;
    [SerializeField] private float DieTimer;
    private void Awake()
    {
        Invoke("Die", DieTimer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<HealthComponent>().TakeDamage(DamageAmount);
            Die();
        }
        else
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}