using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ChunkSpawner : MonoBehaviour
{
    private CarController CarController;
    private GameObject PlayerLink;
    private Transform Player;
    private Chunk[] GamePrefabsCountRoad;
    public Chunk[] ChunkPrefabs;
    public Chunk firstChunk;
    public Chunk newChunk;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    private ArrayList arrayList = new ArrayList();
    private List<Chunk> SpawnPrefab = new List<Chunk>();
    private RotateType rotateType;

    private void Start()
    {
        PlayerLink = GameObject.Find("Player");
        CarController = PlayerLink.GetComponent<CarController>();
        this.Player = PlayerLink.transform;
        spawnedChunks.Add(firstChunk);
        
    }
    private void FixedUpdate()
    {

        if (Vector3.Distance(spawnedChunks[spawnedChunks.Count - 1].End.position, Player.position) < 50f)
        {
            SpawnCheckedBlockLevel();
        }

    }
    private void SpawnChunk(Chunk[] GamePrefabsCountRoad) 
    {
        Chunk newChunk = Instantiate(GamePrefabsCountRoad[UnityEngine.Random.Range(0, GamePrefabsCountRoad.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Start.localPosition;
        newChunk.transform.rotation = spawnedChunks[spawnedChunks.Count - 1].End.rotation;
        this.newChunk = newChunk;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= 4)
        {
            GamePrefabsCountRoad[0].gameObject.transform.position = new Vector3(0, -10, 0);
            StartCoroutine(DestroyObjRoad());
        }

        #region Cleaning
        for (int i = SpawnPrefab.Count; i > 0; i--) //удаление элементов из коллекции 
        {
            SpawnPrefab.RemoveAt(0);
        }
        for (int i = 0; i < GamePrefabsCountRoad.Length; i++)
        {
            GamePrefabsCountRoad[i] = null;
        }
        for (int i = arrayList.Count; i > 0; i--)
        {
            arrayList.RemoveAt(0);
        }
        #endregion
    }
    public void SpawnCheckedBlockLevel()
    {
        Ray RayForward = new Ray(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.transform.forward);
        Ray RayRight = new Ray(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.transform.right);
        Ray RayLeft = new Ray(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.transform.right*-1f);
        RaycastHit hit;
        foreach (var value in Enum.GetValues(typeof(RotateType))) 
        {
            var a = value.ToString();
            arrayList.Add(a);
        }
        if (Physics.Raycast(RayForward, out hit, 130f))
        {
            if (hit.collider.gameObject.GetComponent<ComponentWallToScene>())
            {
                if (hit.distance < 130f)
                {
                    arrayList.Remove(RotateType.ForwardType.ToString());
                }
            }
        }
        if (Physics.Raycast(RayRight, out hit, 130f))
        {
            if (hit.collider.gameObject.GetComponent<ComponentWallToScene>())
            {
                if (hit.distance < 80f)
                {
                    arrayList.Remove(RotateType.Right.ToString());
                }
                if (hit.distance < 130f) 
                {
                    arrayList.Remove(RotateType.ForwardType.ToString());
                }
            }
        }
        if (Physics.Raycast(RayLeft, out hit, 130f))
        {
            if (hit.collider.gameObject.GetComponent<ComponentWallToScene>())
            {
                if (hit.distance < 80f) 
                {
                    arrayList.Remove(RotateType.Left.ToString());
                }
            }
        }
        #region DopLogic

        foreach (var item in ChunkPrefabs)
        {
            var bb = item.gameObject.GetComponent<Chunk>(); //получение ссылки на текущий юнити чанк

            foreach (var ChecType in arrayList) //проверка на тип
            {
                if (bb.rotateType.ToString() == ChecType.ToString())
                {
                    SpawnPrefab.Add(item);
                }
            }
        }
        Chunk[] GamePrefabsCountRoad = new Chunk[SpawnPrefab.Count];
        int CountIndexArrayGamePrefabs = 0;
        foreach (var item in SpawnPrefab)
        {
            GamePrefabsCountRoad[CountIndexArrayGamePrefabs] = item;
            CountIndexArrayGamePrefabs++;
        }
        SpawnChunk(GamePrefabsCountRoad); //передача массива с ChunkPrefab допустимого RotateType

        #endregion
    }
    IEnumerator DestroyObjRoad()
    {
        yield return new WaitForSeconds(1f);
        Destroy(spawnedChunks[0].gameObject);
        spawnedChunks.RemoveAt(0);
    }
}
