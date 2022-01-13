using UnityEngine;

namespace Project.Scripts.MVC
{
    public class GameInitialization
    {
        public GameInitialization(Descriptions descriptions, MonoControllers controllers)
        {
            var factory = new GameObject("Factory").AddComponent<Factory>();
            
            var pool = new PoolChunkRoads(descriptions);
            var RoadSpawnController = new RoadSpawnController(pool, factory.CreateWithTask
                (descriptions.GetView(descriptions.OneRoadPrefab)).GetComponent<Chunk>());

            controllers.Add(pool);
            controllers.Add(RoadSpawnController);


        }
    }
}