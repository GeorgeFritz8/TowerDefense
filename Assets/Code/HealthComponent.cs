using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    private float _startHealth;

    private void Start()
    {
        _currentHealth = _startHealth;  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(float amount)
    {
        print("ik krijg damage");
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Death();    
        }

    }

    private void Death()
    {
        print("ik ben dood");
    }
}
