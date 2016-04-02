using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    float timeBetweenSpawn = 0.5f;
    float timeUntilSpawn = 0f;

    GameObject enemyPrefab;
    void Start()
    {
        enemyPrefab = Resources.Load("Enemy") as GameObject;
        scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
    }

    ScoreKeeper scoreKeeper;
	// Update is called once per frame
	void Update () {
        if (!scoreKeeper.inGame) return;

        if (timeUntilSpawn <= 0)
        {
            timeUntilSpawn = timeBetweenSpawn;
            SpawnEnemy();
        }
        else timeUntilSpawn -= Time.deltaTime;
	}

    void SpawnEnemy()
    {
        GameObject.Instantiate(enemyPrefab,enemySpawnPoint(), Quaternion.identity);
    }

    public float range = 1.5f;
    Vector2 enemySpawnPoint()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        return new Vector2(playerObject.transform.position.x + Random.Range(-range,range),5);
    }
}
