using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    [SerializeField] OrderBehaviourSO townConfigSO;
    [SerializeField] GameObject orderPrefab;
    [SerializeField] bool isOpenOrder=false;
    [SerializeField] List<int> activeOrder;
    List<Transform> spawnPoints;
    int randomIndex=0;
    bool coroutineStarted=false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = townConfigSO.GetOrderSpawnPoint();
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnOrderCO());
    }

    
    IEnumerator SpawnOrderCO()
    {
        if(coroutineStarted){yield break;}
        coroutineStarted = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine Running");
        if(isOpenOrder)
        {
            Debug.Log("Order is Open");
            if(activeOrder.Count<townConfigSO.GetOrderRate())
            {
                Debug.Log("No Order");
                do{
                    randomIndex = Random.Range(0, spawnPoints.Count-1);
                }while(activeOrder.Contains(randomIndex));
                activeOrder.Add(randomIndex);
                Instantiate(orderPrefab,spawnPoints[randomIndex].position,Quaternion.identity);
            }
        }
        coroutineStarted =false;
        yield break;
    }
}
