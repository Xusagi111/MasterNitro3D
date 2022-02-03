using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ChunkSpawner : MonoBehaviour
{
    CarController CarController;
    GameObject PlayerLink;
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk[] GamePrefabsCountRoad;
    public Chunk firstChunk;
    public List<Chunk> spawnedChunks = new List<Chunk>();
    public ArrayList arrayList = new ArrayList();
    public List<Chunk> SpawnPrefab = new List<Chunk>();
    public Chunk newChunk;
    private int Countspawn = 0; 
    RotateType rotateType;

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
            SpavnCheckedBlockLevel();
        }
    }
    private void SpawnChunk(Chunk[] GamePrefabsCountRoad) // выборка из доступных направлений и спавн рандомной дороги по направлениям которые доступны
    {
       
        //SpavnCheckedBlockLevel();
        Chunk newChunk = Instantiate(GamePrefabsCountRoad[UnityEngine.Random.Range(0, GamePrefabsCountRoad.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Start.localPosition;
        newChunk.transform.rotation = spawnedChunks[spawnedChunks.Count - 1].End.rotation;
        this.newChunk = newChunk;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= 4)
        {
            GamePrefabsCountRoad[0].gameObject.transform.position = new Vector3(0, -10, 0);
            StartCoroutine("DestroyObjRoad");
        }
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
    }
    public void SpavnCheckedBlockLevel()
    {
        Ray RayForward = new Ray(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.transform.forward);
        Ray RayRight = new Ray(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.transform.right);
        Ray RayLeft = new Ray(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.transform.forward);
        Debug.DrawRay(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.forward * 130f, Color.red);
        Debug.DrawRay(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.right * 130f, Color.red);
        Debug.DrawRay(newChunk.ChecBlockLevel.position, newChunk.ChecBlockLevel.right * -130f, Color.red);
        RaycastHit hit;
        foreach (var value in Enum.GetValues(typeof(RotateType))) // начало метода спавн SpavnCheckedBlockLevel()
        {
            var a = value.ToString();
            arrayList.Add(a);
        }
        
        if (Physics.Raycast(RayForward, out hit, 130f))
        {
            if (hit.collider.gameObject.GetComponent<SceneObjectTexture>())
            {
                var a = hit.distance;
                Debug.Log("RayForward" + a);
                if (a < 130f) //текущие сравнение дистанции
                {
                    arrayList.Remove(RotateType.ForwardType.ToString());
                }
            }
        }
        if (Physics.Raycast(RayRight, out hit, 130f))
        {
            if (hit.collider.gameObject.GetComponent<SceneObjectTexture>())
            {
                var a = hit.distance;
                Debug.Log("RayRight" + a);
                if (a < 80f) //текущие сравнение дистанции
                {
                    arrayList.Remove(RotateType.Right.ToString());
                }
                if (a < 130f)
                {
                    arrayList.Remove(RotateType.ForwardType.ToString());
                }
              
                
            }
        }
        if (Physics.Raycast(RayLeft, out hit, -130f))
        {
            if (hit.collider.gameObject.GetComponent<SceneObjectTexture>())
            {
                var a = hit.distance;
                Debug.Log("RayLeft" + a);
                if (a < 80f) //текущие сравнение дистанции
                {
                    arrayList.Remove(RotateType.Left.ToString());
                }
            }
        }
        #region DopLogic

        Countspawn++;

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
        int b = 0;
        foreach (var item in SpawnPrefab)
        {
            GamePrefabsCountRoad[b] = item;
            b++;
        }
        SpawnChunk(GamePrefabsCountRoad);

        #endregion
    }
    IEnumerator DestroyObjRoad()
    {
        yield return new WaitForSeconds(1f);
        Destroy(spawnedChunks[0].gameObject);
        spawnedChunks.RemoveAt(0);

    }
}
