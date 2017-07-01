using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupGenerator : MonoBehaviour {

    public GameObject[] pickupTiles;
    public int maxPickupsOnScreen = 4;
    private int pickupsOnScreen = 0;
    private Transform boardHolder;
    private Transform gameManager;
    private GameObject toInstantiate;
    private GameObject instance;

    private List<Vector3> gridPositions = new List<Vector3>();
    private float[] offsets;

    //Create game object that will hold the generated game level
    void BoardSetup()
    {
        gameManager = GetComponent<GameManager>().transform;
        boardHolder = new GameObject("Board").transform;
        boardHolder.transform.SetParent(gameManager);
    }

    private void Update()
    {
        if (pickupsOnScreen < maxPickupsOnScreen)
        {
            int randomValue = Random.Range(0, 60) ;
            Debug.Log(randomValue);
            if (randomValue == 5 || randomValue == 50 )
            {
                GenerateNewTile();
            }
        }        
    }

    public void GenerateNewTile()
    {
        //Create a random number between 0 and tile size index
        toInstantiate = pickupTiles[Random.Range(0, pickupTiles.Length)];
        //Spawn background tile at an offset from the prevous tile 

         instance = Instantiate(toInstantiate, new Vector3(this.transform.position.x , Random.Range(-3,3)), Quaternion.identity) as GameObject;

        //parent objects to Board holder to make neater inside unity 
        instance.transform.SetParent(boardHolder);
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
       // LayoutObjectAtRandom(backgroundTiles, tileCount.minimum, tileCount.maximum);
        int enemyCount = (int)Mathf.Log(level, 2f);
       // LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
    }
}
