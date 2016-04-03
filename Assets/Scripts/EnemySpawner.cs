using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float timeBetweenSpawn = 0.5f;
	float minTimeBetweenSpawn = 0.5f;
    float timeUntilSpawn = 0f;
	int enemiesToSpawn = 2;

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
		GameObject.Instantiate(enemyPrefab,enemySpawnPoint(_range), Quaternion.identity);
		for (int i = 0; i < enemiesToSpawn; i++) {
			GameObject.Instantiate(enemyPrefab,secondaryEnemiesSpawnPoint(_range,5), Quaternion.identity);
		}
    }

    public float _range = 1.5f;
	Vector2 enemySpawnPoint(float range)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        return new Vector2(playerObject.transform.position.x + Random.Range(-range,range),5);
    }

	Vector2 secondaryEnemiesSpawnPoint(float range,float adder){
		bool negative = randomBool ();
		Vector2 basePoint = enemySpawnPoint (range);
		if (negative)
			basePoint.x -= adder;
		else
			basePoint.x += adder;
		
		return basePoint;
	}

	bool randomBool(){
		return Random.value > 0.5;
	}
}
