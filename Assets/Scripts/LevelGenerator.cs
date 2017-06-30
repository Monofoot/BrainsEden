using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public int levelTileLength = 10;
    //List of sprite tile prefabs 
    public List<GameObject> levelSprites;

    void Update()
    {
        //Check every frame if player requires new tiles to be generated
        ProceduralLevelGenerator();
    }

    void ProceduralLevelGenerator()
    {
        //Generate random idex to spawn random predefiend sprite onto level
        int randomIndex = Random.Range(0, levelSprites.Count);

        if (CheckThreashold())
        {
            CreateTile(randomIndex);
        }

    }

    bool CheckThreashold()
    {
        bool passedThresh = false;
        //Check if player/ camera has passed threashold for new tile to be created

        if (true)
        {
            passedThresh = true; }
        else
        {
            passedThresh = false;
        }

        return passedThresh;
    }

    void CreateTile(int index)
    {
        //Test random number generator
        Debug.Log(index);

        //create a new level sprite based on index argument
        Instantiate(levelSprites[index]);

    }

   
}
