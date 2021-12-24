using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk firstChunk;
    public Transform Transform1;

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
        if(Transform1 != null)
        Debug.DrawLine(Transform1.position, Transform1.position + Transform1.forward * 10);
    }
    public void ChechHouse(Chunk chunk)
    {
        Transform1 = chunk.End;
        Ray ray = new Ray(Transform1.position, Transform1.forward);
        Debug.Log(Transform1.position);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.gameObject.SetActive(false);
            Debug.Log(hit.collider.name);
            
        }
    }
    private void SpawnChunk()
    {

        var index = Random.Range(0, ChunkPrefabs.Length);  
        ChechHouse(ChunkPrefabs[index]);
        Chunk newChunk = Instantiate(ChunkPrefabs[index]);
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
