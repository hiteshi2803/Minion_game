using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);//what you want to spawn, where and the rotation. returns that to the temp GameObject.(Quaternion.identity specifies no rotation)
        nextSpawnPoint = temp.transform.GetChild(1).transform.position; // first child (index) of the GroundTile GameObject

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }

    }
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 2)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

}
