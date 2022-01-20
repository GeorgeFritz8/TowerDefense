using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float AmountOfWaves;

    private void Start()
    {
        canSpawn = true;
        CurrentWave = -1;
        AmountOfWaves = Waves.Length;
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
        if (CurrentWave > Waves.Length)
        {
            SceneManager.LoadScene("WinScreen");
        }
        for (int i = 0; i < Waves[CurrentWave].EnemyCount; i++)
        {
            Instantiate(Waves[CurrentWave].Enemy[Random.Range(0, Waves[CurrentWave].Enemy.Length)], SpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
}
[System.Serializable]
public class Wave
{
    public int EnemyCount;
    public GameObject[] Enemy;
}
