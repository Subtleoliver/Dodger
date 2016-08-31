using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float timeBetweenSpawn = 0.5f;
    float timeUntilSpawn = 0f;

    float minTimeBetweenSpawn = 0.5f;
    float maxTimeBetweenSpawn = 1.0f;

    
    public int lowestX = -8;
    public int highestX = 8;

    public int spaceWidth = 3;

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
        bool[] dontSpawnInPos = new bool[Mathf.Abs(lowestX) + highestX];

        int dontSpawnPosBegin = Random.Range(0,dontSpawnInPos.Length - spaceWidth);
        for (int i = 0; i < spaceWidth; i++)
            dontSpawnInPos[dontSpawnPosBegin + i] = true;

		for (int i = 0; i < dontSpawnInPos.Length; i++) {
            if(!dontSpawnInPos[i])
			    GameObject.Instantiate(enemyPrefab,new Vector3(i + lowestX, 10 + Random.Range(0, heightRange)), Quaternion.identity);
		}
    }

	Vector2 spawnPoint(){
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
        Vector2 spawnPos = new Vector2(playerObject.transform.position.x + Random.Range(0, range) * randomPosOrNeg(), 10 + Random.Range(0, heightRange));
        
        return spawnPos;
    }
		
	public float range = 10f;
	public float heightRange = 1.5f;

	int randomPosOrNeg(){
		float i = Random.value;
		if (i <= 0.5)
			return -1;

		return 1;
	}
}
