using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int Kills;
    private bool canSelect;
    [HideInInspector] public bool isSelected;
    public float shootRate = 0.2f;
    private Transform Target;
    public float moveSpeed = 4f;
    [SerializeField] private float range = 15f;
    private string enemyTag = "Enemy";
    [SerializeField] private Tower TowerObj;
    public Transform partToRotate;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("EnableSelect", 1f);
        InvokeRepeating("UpdateTarget", 0f, shootRate);
    }

    private void UpdateTarget()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
            gameObject.GetComponent<Shooting>().Shoot(Target);
        }
        else
        {
            Target = null;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Target == null)
            return;
        

            Quaternion lookOnLook = Quaternion.LookRotation(Target.transform.position - transform.position);
            lookOnLook.x = 0;
            lookOnLook.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, moveSpeed * Time.deltaTime);
        
    }
}