using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeChecker : MonoBehaviour
{
    [SerializeField] private bool toggle;
    [SerializeField] float minMax = 0;
    private float startThickness;
    [SerializeField] private int speed;
    [SerializeField] private float gizmoThickness;
    [SerializeField] private float range;
    [SerializeField] private LayerMask layer;
    private void Awake()
    {
        toggle = true;
        startThickness = gizmoThickness;
    }
    public Enemy GetFirstEnemyInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, range, layer);
        print(cols.Length);
        if (cols.Length <= 0)
        {
            return null;
        }
        return cols[0].GetComponent<Enemy>();
    }

    void Update()
    {
        //gizmoThickness = Mathf.Sin(Time.time * speed) * 30;
        if (gizmoThickness == 30)
        {
            gizmoThickness = Mathf.Lerp(2, minMax, Time.time * speed);
        }
        else
        {
            toggle = false;
            gizmoThickness = Mathf.Lerp(2, -minMax, Time.time * speed);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int i = 0; i < gizmoThickness; i++)
        {
            Gizmos.DrawWireSphere(transform.position, range + i / 100f);
        }
    }
}