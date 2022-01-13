using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Scripts.MVC
{
    public class PoolChunkRoads : IInitialization
    {
       
        private Descriptions _descriptions;

        private List<Chunk> _roadsOne;
        private List<Chunk> _roadsTwo;

        private GameObject _container;

        public PoolChunkRoads(Descriptions descriptions)
        {
            _descriptions = descriptions;
        }
        
        public void Initialization()
        {
            _roadsOne = new List<Chunk>();
            _roadsTwo = new List<Chunk>();
            _container = new GameObject("Container roads");

            for (int i = 0; i < _descriptions.CountRoad; i++)
            {
                InitCollection(_descriptions.GetView(_descriptions.OneRoadPrefab).Result, _roadsOne, _container.transform);
                InitCollection(_descriptions.GetView(_descriptions.TwoRoadPrefab).Result, _roadsTwo, _container.transform);
            }
            
            
            
        }
        
        private void InitCollection(GameObject obj, List<Chunk> collection, Transform container)
        {
            var poolObject = Object.Instantiate(obj, container);
            poolObject.SetActive(false);
            poolObject.AddComponent<Chunk>();
            collection.Add(poolObject.GetComponent<Chunk>());
        }

        public Chunk GetChunkRoad(int type)
        {
            switch ((ChunkType)type)
            {
                case ChunkType.One :
                    return GetObject(_roadsOne);
                case ChunkType.Two :
                    return GetObject(_roadsTwo);
                default:
                    return null;
            }
            
        }
        
        

        public Chunk GetObject(List<Chunk> roads)
        {
            var road = roads[roads.Count-1];
            Debug.LogWarning($"{roads.Count - 1}, {roads[roads.Count-1]}");
            roads.Remove(road);
            road.SetActive(true);
            return road;      
        }

        public void ReturnChunkRoad(Chunk road)
        {
            ReturnHitEffectToPool(road, _roadsOne);
        }
        
        public void ReturnHitEffectToPool(Chunk road, List<Chunk> roads)
        {
            road.SetActive(false);
            road.transform.position = _container.transform.position;
            roads.Add(road);
        }
    }
}