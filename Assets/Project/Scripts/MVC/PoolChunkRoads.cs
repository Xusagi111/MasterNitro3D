using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.MVC
{
    public class PoolChunkRoads
    {
        [SerializeField] private int _countRoad;
        [SerializeField] private Chunk _road;

        private List<Chunk> _roads;

        private GameObject _container;

        public PoolChunkRoads()
        {
        }

        public void Initialization()
        {
            _roads = new List<Chunk>();
            _container = new GameObject("Container roads");

            for (int i = 0; i < _countRoad; i++)
            {
                InitCollection(_road, _roads, _container.transform);    
            }
            
        }
        
        private void InitCollection(Chunk obj, List<Chunk> collection, Transform container)
        {
            var poolObject = Object.Instantiate(obj, container);
            poolObject.SetActive(false);
            collection.Add(poolObject);
        }

        public Chunk GetChunkRoad()
        {
            return GetObject(_roads);
        }

        public Chunk GetObject(List<Chunk> roads)
        {
            var road = roads[0];
            roads.Remove(road);
            road.SetActive(true);
            return road;      
        }

        public void ReturnChunkRoad()
        {
            ReturnHitEffectToPool(_road, _roads);
        }
        
        public void ReturnHitEffectToPool(Chunk road, List<Chunk> roads)
        {
            road.SetActive(false);
            roads.Add(road);
        }
    }
}