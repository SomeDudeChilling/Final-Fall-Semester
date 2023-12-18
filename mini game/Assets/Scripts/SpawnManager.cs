using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float areaRange = 20f;
    public int coinAmount = 10;
    public GameObject collectibleObject;
    public GameObject enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnRandomEnemy();
        StartCoroutine(CreateRandomAmountOfEnemies());
        SpawnCollectibleObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        Instantiate(enemyObject, CreateRandomSpawnPos(), enemyObject.transform.rotation);
    }

    public void SpawnCollectibleObject()
    {
        for(int i = 0; i < coinAmount; i++)
        {
        Instantiate(collectibleObject, CreateRandomSpawnPos(), collectibleObject.transform.rotation);
        }
        coinAmount = 1;
    }

    Vector3 CreateRandomSpawnPos()
    {
        float xValue = Random.Range(-areaRange, areaRange);
        float zValue = Random.Range(-areaRange, areaRange);
        Vector3 randomPosition = new Vector3(xValue, 1f, zValue);

        return randomPosition;
    }

    IEnumerator CreateRandomAmountOfEnemies()
    {
        while(true)
        {
            int amountOfTime = Random.Range(1, 8);

            yield return new WaitForSeconds(amountOfTime);

            int numberOfEnemies = Random.Range(1, 3);
            for (int i = 0; i < numberOfEnemies; i++)
            {
                SpawnRandomEnemy();
            }
        }
    }
}
