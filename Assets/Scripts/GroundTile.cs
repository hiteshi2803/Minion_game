using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab1;
    [SerializeField] GameObject obstaclePrefab2;
    [SerializeField] GameObject obstaclePrefab3;
    [SerializeField] GameObject coinPrefab;


    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        // SpawnObstacle();
        // SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2); // destroys gameObject 2 seconds after the player leaves it
    }

    public void SpawnObstacle()
    {
        //Random point to spawn obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        int obstacleNumber = Random.Range(0, 3);
        if (obstacleNumber == 0)
        {
            Instantiate(obstaclePrefab1, spawnPoint.position, Quaternion.identity, transform);
        }
        if (obstacleNumber == 1)
        {
            Instantiate(obstaclePrefab2, spawnPoint.position, Quaternion.identity, transform);
        }
        if (obstacleNumber == 2)
        {
            Instantiate(obstaclePrefab3, spawnPoint.position, Quaternion.identity, transform);
        }

    }

    public void SpawnCoins()
    {
        int coinsNumber = 10;
        for (int i = 0; i < coinsNumber; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 spawnPoint = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (spawnPoint != collider.ClosestPoint(spawnPoint))
        {
            spawnPoint = GetRandomPointInCollider(collider);
        }

        spawnPoint.y = 1;
        return spawnPoint;
    }

}
