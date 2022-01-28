using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChunkSpawner : MonoBehaviour
{
    CarController CarController;
    GameObject PlayerLink;
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk firstChunk;
    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        PlayerLink = GameObject.Find("Player");
        CarController = PlayerLink.GetComponent<CarController>();
        this.Player = PlayerLink.transform;
        spawnedChunks.Add(firstChunk);
    }
    private void Update()
    {
       
        if (Vector3.Distance(spawnedChunks[spawnedChunks.Count - 1].End.position, Player.position) < 50f)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Start.localPosition;
        newChunk.transform.rotation = spawnedChunks[spawnedChunks.Count - 1].End.rotation;
        spawnedChunks.Add(newChunk);
        
            if (spawnedChunks.Count >= 4)
            {
                spawnedChunks[0].gameObject.transform.position = new Vector3(0, -10, 0);
                StartCoroutine("DestroyObjRoad");
             }
        
        
    }
    IEnumerator DestroyObjRoad()
    {
        yield return new WaitForSeconds(1f);
        Destroy(spawnedChunks[0].gameObject);
        spawnedChunks.RemoveAt(0);

    }
}
