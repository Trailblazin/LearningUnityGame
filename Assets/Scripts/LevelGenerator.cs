using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    //Object used for singleton, allows us to access the level generator
    public static LevelGenerator instance;
    //List of level chunk blueprints, used to copy into the level
    public List<LevelChunk> levelPrefabs = new List<LevelChunk>();
    //Starting point of the first level chunk, and hence, the level
    public Transform levelStartPoint;
    //List of all chunks currently in the level
    public List<LevelChunk> chunks = new List<LevelChunk>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateInitialChunks();
    }

    public void GenerateInitialChunks()
    {
        for (int i=0; i<2; i++)
        {
            AddChunk();
        }
    }

    public void AddChunk()
    {
        //Pick a random number between 0 and the number of level prefabs
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        //Instantiates, created a copy or an instance, of a random level prefab and stores it as a chunk
        LevelChunk chunk = (LevelChunk)Instantiate(levelPrefabs[randomIndex]);
        chunk.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //If there are no prior added chunks in the list
        if (chunks.Count == 0)
        {
            //Assign position of first chunk
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            //Use exit point from the most recently spawned chunk as the spawn point for a new chunk
            spawnPosition = chunks[chunks.Count - 1].exitPoint.position;
        }

        chunk.transform.position = spawnPosition;
        //Add the instanced chunk to the chunks list
        chunks.Add(chunk);
    }
    
    public void RemoveOldestChunk()
    {
        //Takes the first chunk from the chunks list, removes it from the list then destroys its respective game object
        LevelChunk oldestChunk = chunks[0];
        chunks.Remove(oldestChunk);
        Destroy(oldestChunk.gameObject);
    }
}
