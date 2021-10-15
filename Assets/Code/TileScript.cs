using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool _isBuildable;
    public bool GetIsBuildable()
    {
        return _isBuildable;
    }
}