using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk firstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
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
        Debug.Log(spawnedChunks[spawnedChunks.Count - 1].End.rotation);
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
}
