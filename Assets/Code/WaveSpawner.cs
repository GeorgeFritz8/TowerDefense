using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector] public bool canSpawn;
    public GameObject Enemy;
    public float SpawnTimer;
    public Vector3 SpawnPosition;
    public int EnemyCount;
    public KeyCode WaveStartButton;
    public Wave[] Waves;
    public int CurrentWave;

    private void Start()
    {
        canSpawn = true;
        CurrentWave = -1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(WaveStartButton))
        {
            CurrentWave++;
            StartCoroutine(StartWave());
        }
    }
    public IEnumerator StartWave()
    {
        for (int i = 0; i < Waves[CurrentWave].EnemyCount; i++)
        {
            Instantiate(Waves[CurrentWave].Enemy, SpawnPosition, transform.rotation);
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
}
[System.Serializable]
public class Wave
{
    public int EnemyCount;
    public GameObject Enemy;
}
