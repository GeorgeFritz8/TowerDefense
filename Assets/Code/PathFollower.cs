using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;
    public bool AOEDamage;
    public int AOEDamageAmount;
    private Path _path;
    private Waypoint _currentWaypoint;

    private void Awake()
    {
        SetupPath();
    }
    private void SetupPath()
    {
        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
    }
    public void PathComplete()
    {
        FindObjectOfType<HealthComponent>().TakeDamage(1);
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        float dist = Vector3.Distance(transform.position, new Vector3(_currentWaypoint.GetPosition().x, 0, _currentWaypoint.GetPosition().z));
        if (dist <= _arrivalThreshold)
        {
            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
        }

        transform.LookAt(new Vector3(_currentWaypoint.GetPosition().x,0,_currentWaypoint.GetPosition().z));
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("AOE"))
        {
            print("egg");
            AOEDamage = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AOE"))
        {
            AOEDamage = false;
        }
    }
    public void TakeDamage()
    {
        if (AOEDamage)
        {
            transform.GetChild(0).GetComponent<HealthComponent>().TakeDamage(AOEDamageAmount);
        }
    }
}