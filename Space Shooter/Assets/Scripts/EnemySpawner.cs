using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private Projectile projectileScript;
    public PlayerController playerReference;
    public Vector3 spawnValues;
    public float spawnDelay;
    public float spawnDelayMin;
    public float spawnDelayMax;
    public int startDelay;
    private int randEnemy;
    public bool stopEnemySpawning = false;
    public Vector3 bossSpawnPosition;
    public bool bossHasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startDelay);

        while (!stopEnemySpawning)
        {
            //randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), 0);

            Instantiate (enemies[0], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

            if (playerReference.enemiesKilled >= 3 && !bossHasSpawned)
            {
                //Debug.Log("Boss Spawned");
                Instantiate (enemies[1], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
                bossHasSpawned = true;
            }

            yield return new WaitForSeconds(spawnDelay);           
        }

        
    }
}
