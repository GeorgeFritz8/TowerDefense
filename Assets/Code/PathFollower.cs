using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;
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
        //FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
        Destroy(gameObject);
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, _currentWaypoint.transform.position);
        if (dist <= _arrivalThreshold)
        {
            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
        }

        transform.LookAt(_currentWaypoint.GetPosition());
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}