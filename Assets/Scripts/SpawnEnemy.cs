using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;

    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;

    public int delay;
    public int minDelay;
    public int maxDelay;
    public int delayBeforeSpawn;

    private void Start()
    {
        delayBeforeSpawn = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        if (delay > delayBeforeSpawn)
        {
            SpawnEnemies();
        }

        delay++;
    }

    public void SpawnEnemies()
    {
        float randomPosX = Random.Range(minPosX, maxPosX);
        float randomPosY = Random.Range(minPosY, maxPosY);
        delay = 0;
        Instantiate(enemies[Random.Range(0, enemies.Length-1)], new Vector3(randomPosX, randomPosY, 0), Quaternion.identity);
        delayBeforeSpawn = Random.Range(minDelay, maxDelay);
    }
}