using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageGenerator : MonoBehaviour
{
    [SerializeField] GameObject packagePrefab;

    bool coroutineStarted=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeneratePackage();
    }

    void GeneratePackage()
    {
        if(transform.childCount<1)
        {
        StartCoroutine(MakePackageCO());
        }
    }

    IEnumerator MakePackageCO()
    {
        if(coroutineStarted){yield break;}
        coroutineStarted=true;
        yield return new WaitForSeconds(5f);
        Instantiate(packagePrefab,gameObject.transform.position,Quaternion.identity,gameObject.transform);
        Debug.Log("Package Created");
        yield return new WaitForSeconds(2f);
        coroutineStarted=false;
        yield break;
    }
}
