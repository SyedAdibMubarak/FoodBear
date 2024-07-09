using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TownConfigSO", menuName = "TownConfigSO", order =0)]

public class OrderBehaviourSO : ScriptableObject
{
    [SerializeField] Transform houses;
    [SerializeField] float orderRate = 1f;
    [SerializeField] float orderFirstTimer =5f;
    [SerializeField] float orderSecondTimer =10f;

    public List<Transform> GetOrderSpawnPoint()
    {
        List<Transform> spawnPoints = new List<Transform>();
        foreach(Transform child in houses)
        {
            spawnPoints.Add(child);
        }
        return spawnPoints;
    }

    public float GetOrderRate()
    {
        return orderRate;
    }

    public float GetOrderFirstTimer()
    {
        return orderFirstTimer;
    }

    public float GetOrderSecondTimer()
    {
        return orderSecondTimer;
    }

}
