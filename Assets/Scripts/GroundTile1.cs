using UnityEngine;

public class GroundTile1 : MonoBehaviour {

    GroundSpawner groundSpawner1;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject npcPrefab;

    private void Start () {
        groundSpawner1 = GameObject.FindObjectOfType<GroundSpawner>();
	}

    private void OnTriggerExit (Collider other)
    {
        groundSpawner1.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }


    public void SpawnCoins ()
    {
        int coinsToSpawn = 3;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    public void SpawnNPC ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}