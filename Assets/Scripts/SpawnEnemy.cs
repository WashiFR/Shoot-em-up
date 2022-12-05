using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;

    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;

    public float delay;
    public float minDelay;
    public float maxDelay;
    public float delayBeforeSpawn;

    private void Start()
    {
        delayBeforeSpawn = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        if (delay > delayBeforeSpawn && !GameOver.instance.gameIsOver && StartGame.instance.gameIsStarted)
        {
            SpawnEnemies();
        }

        delay += Time.deltaTime;
    }

    public void SpawnEnemies()
    {
        float randomPosX = Random.Range(minPosX, maxPosX);
        float randomPosY = Random.Range(minPosY, maxPosY);

        delay = 0;
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(randomPosX, randomPosY, 0), Quaternion.identity);
        delayBeforeSpawn = Random.Range(minDelay, maxDelay);
    }
}
