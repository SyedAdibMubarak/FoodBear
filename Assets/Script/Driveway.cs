using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driveway : MonoBehaviour
{
    [SerializeField] bool hasOrder =false;
    bool deliveryMade = false;

    public void OnDelivery(bool hasPackage)
    {
        if(hasPackage)
        {
            deliveryMade = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Customer")
        {
            Debug.Log("We have order");
            hasOrder = true;
        }
        else if(other.gameObject.tag == "Player")
        {
            Debug.Log("We have driver");
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(deliveryMade)
        {
            if(other.gameObject.tag== "Customer")
            {
                Destroy(other.gameObject);
                deliveryMade=false;
                hasOrder=false;
            }
        }
    }
}
