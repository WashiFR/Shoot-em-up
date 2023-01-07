using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;

    public int minPosX;
    public int maxPosX;
    public int minPosY;
    public int maxPosY;

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
        int randomPosX = Random.Range(minPosX, maxPosX);
        int randomPosY = Random.Range(minPosY, maxPosY);

        delay = 0;
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(randomPosX, randomPosY, 0), Quaternion.identity);
        delayBeforeSpawn = Random.Range(minDelay, maxDelay);
    }
}
