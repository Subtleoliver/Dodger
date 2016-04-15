using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float timeBetweenSpawn = 0.5f;
	float minTimeBetweenSpawn = 0.5f;
    float timeUntilSpawn = 0f;

	public int maxEnemiesToSpawn = 10;
	public int minEnemiesToSpawn = 2;

	public void changeSpawnTime(float change){
		float newTime = timeBetweenSpawn + change;
		if (newTime >= minTimeBetweenSpawn)
			timeBetweenSpawn = newTime;
	}

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
		int enemiesToSpawn = Random.Range (minEnemiesToSpawn, maxEnemiesToSpawn);
		for (int i = 0; i < enemiesToSpawn; i++) {
			GameObject.Instantiate(enemyPrefab,spawnPoint(), Quaternion.identity);
		}
    }

	Vector2 spawnPoint(){
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		return new Vector2(playerObject.transform.position.x + Random.Range(0,range)*randonPosOrNeg(),10 + Random.Range(0,heightRange));
	}
		
	public float range = 10f;
	public float heightRange = 1.5f;

	int randonPosOrNeg(){
		float i = Random.value;
		if (i <= 0.5)
			return -1;

		return 1;
	}
}
