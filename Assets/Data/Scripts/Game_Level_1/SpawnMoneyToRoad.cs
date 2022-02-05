using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoneyToRoad : MonoBehaviour
{
    [SerializeField] GameObject Money;
    [SerializeField] Transform[] _point;
    [SerializeField] int MaxCountPoint = 3;
    
    void Start()
    {
        RandomSpawnObject();
    }
    public void RandomSpawnObject()
    {
        int[] arrayIndexPoints = new int[MaxCountPoint];
        for (int i = 0; i < arrayIndexPoints.Length ; )
        {
            int Count = 0;
            var a = Random.Range(1, _point.Length);
            for (int g = 0; g < arrayIndexPoints.Length ; g++)
            {
                if (a == arrayIndexPoints[g])
                {
                    break;
                }
            }
            if (Count == 0)
            {
                arrayIndexPoints[i] = a;
                i++;
            }
        }

        for (int i = 0; i < MaxCountPoint; i++)
        {
            Instantiate(Money, _point[arrayIndexPoints[i]]);
        }
    }
}
