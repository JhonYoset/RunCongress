using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject groundTile1;
    [SerializeField] GameObject groundTile2;
    Vector3 nextSpawnPoint;
    int groundTileCount = 0; // Contador de GroundTile creados

    public void SpawnTile(bool spawnItems)
    {
        if (groundTileCount <= 5)
        {
            GameObject temp = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;

            if (spawnItems)
            {
                temp.GetComponent<GroundTile1>().SpawnObstacle();
                temp.GetComponent<GroundTile1>().SpawnCoins();
                temp.GetComponent<GroundTile1>().SpawnNPC();
            }
            /*
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;

            if (spawnItems)
            {
                temp.GetComponent<GroundTile>().SpawnObstacle();
                temp.GetComponent<GroundTile>().SpawnCoins();
  
            }*/
            /*
            GameObject temp = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            if (spawnItems)
            {
                temp.GetComponent<GroundTile1>().SpawnObstacle();
                temp.GetComponent<GroundTile1>().SpawnCoins();
                temp.GetComponent<GroundTile1>().SpawnNPC();
            }
            */
            /*
            GameObject temp = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            if (spawnItems)
            {
                temp.GetComponent<GroundTile2>().SpawnObstacle();
                temp.GetComponent<GroundTile2>().SpawnCoins();
                temp.GetComponent<GroundTile2>().SpawnNPC();
            }*/
        }
        if (groundTileCount > 5 && groundTileCount<15)
        {/*
            GameObject temp = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;

            if (spawnItems)
            {
                temp.GetComponent<GroundTile1>().SpawnObstacle();
                temp.GetComponent<GroundTile1>().SpawnCoins();
                temp.GetComponent<GroundTile1>().SpawnNPC();
            }*/
            /*GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;

            if (spawnItems)
            {
                temp.GetComponent<GroundTile>().SpawnObstacle();
                temp.GetComponent<GroundTile>().SpawnCoins();  
            }*/
            GameObject temp = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            if (spawnItems)
            {
                temp.GetComponent<GroundTile2>().SpawnObstacle();
                temp.GetComponent<GroundTile2>().SpawnCoins();
                temp.GetComponent<GroundTile2>().SpawnNPC();
            }
        }
        groundTileCount++;
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
