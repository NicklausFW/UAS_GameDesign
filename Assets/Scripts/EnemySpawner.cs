using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject alien;
    public Vector2 spawnValue;
    public int alienCount = 10;
    public float spawnWait = 2;
    public float startWait = 1;
    public float waveWait = 8;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < alienCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(alien, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }
}
