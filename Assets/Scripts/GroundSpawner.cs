using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    int groundTileCount = 0; // Contador de GroundTile creados

    public void SpawnTile(bool spawnItems)
    {
        if (groundTileCount < 10)
        {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;

            if (spawnItems)
            {
                temp.GetComponent<GroundTile>().SpawnObstacle();
                temp.GetComponent<GroundTile>().SpawnCoins();
            }

            groundTileCount++;
        }
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++) // Cambia el límite a 10 para crear solo 10 GroundTile
        {
            if (i < 3)
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
