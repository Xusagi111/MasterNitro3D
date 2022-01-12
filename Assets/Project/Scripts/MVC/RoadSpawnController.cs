using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Project.Scripts.MVC
{
    public class RoadSpawnController : MonoBehaviour
    {
        private PoolChunkRoads _poolRoads;
        private Chunk newChunk;
        
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

        public void GetPool(PoolChunkRoads pool)
        {
            _poolRoads = pool;
        }

        private void SpawnChunk()
        {
            newChunk = _poolRoads.GetChunkRoad(); 
                
               // newChunk = Object.Instantiate(ChunkPrefabs[UnityEngine.Random.Range(0, ChunkPrefabs.Length)]);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Start.localPosition;
            newChunk.transform.rotation = spawnedChunks[spawnedChunks.Count - 1].End.rotation;
            Debug.Log(spawnedChunks[spawnedChunks.Count - 1].End.rotation);
            spawnedChunks.Add(newChunk);

            if (spawnedChunks.Count >= 3)
            {
                _poolRoads.ReturnChunkRoad();
                spawnedChunks.RemoveAt(0);
            }
        }
    }
}