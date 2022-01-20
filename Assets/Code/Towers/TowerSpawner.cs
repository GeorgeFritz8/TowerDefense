using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour

{
    private float TowerPrice = 50;
    private GameObject TowerToPlace;
    public void PlaceTower()
    {
        print("Egg");
        if (FindObjectOfType<Wallet>().currentBalance >= TowerPrice)
        {
            FindObjectOfType<Wallet>().RemoveMoney(TowerPrice);
            TowerToPlace = FindObjectOfType<TowerList>().Towers[Random.Range(0, 5)];
            Instantiate(TowerToPlace, transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
        } 
    }
}
