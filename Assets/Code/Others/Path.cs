using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private Waypoint[] _waypoints;
    public Waypoint GetPathStart()
    {
        return _waypoints[0];
    }

    public Waypoint GetPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }


    public Waypoint GetNextWaypoint(Waypoint currentWaypoint)
    {
        int result = 0;
        int index = Array.IndexOf(_waypoints, currentWaypoint);
        if(index + 1 < _waypoints.Length)
        {
            result = index + 1;
        }
        else
        {
            return GetPathEnd();
        }
        return _waypoints[result];
    }

}
