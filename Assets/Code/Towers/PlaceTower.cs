using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour

{
    public Camera mainCamera;
    public LayerMask layermask;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layermask))
            {
                raycastHit.collider.GetComponent<TowerSpawner>().PlaceTower();
            }
        }
    }
}
