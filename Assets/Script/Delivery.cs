using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);  
    [SerializeField] ParticleSystem cashMoneySplash;
    [SerializeField] AudioClip deliverySuccessKaching;
    [SerializeField]  bool hasPackage = false;
    [SerializeField] bool canDeliver = false;
    [SerializeField] Button deliveryButton;

    SpriteRenderer spriteRenderer;
    Driveway driveway;
    MoneyTracker moneyTracker;
    bool coroutineStarted = false;

    
   

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        moneyTracker = FindObjectOfType<MoneyTracker>();
    }

    void Update()
    {
        Deliverbility();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You've hit a child, nice");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(other.gameObject);
        }
        if(other.tag == "Driveway" && hasPackage)
        {
            Debug.Log("In A Driveway");
            canDeliver=true;
            driveway = other.GetComponent<Driveway>();
        }
    }

    void Deliverbility()
     {
        if(canDeliver)
        {
            deliveryButton.interactable = true;
            if(Input.GetKey(KeyCode.E))
            {
                MakeDelivery();
            }
        }
        else
        {
            deliveryButton.interactable = false;
        }
     }

     public void MakeDelivery()
     {
        StartCoroutine(ProcessDeliveryCO());
     }

     IEnumerator ProcessDeliveryCO()
     {
        if(coroutineStarted){yield break;}
        coroutineStarted=true;
        driveway.OnDelivery(hasPackage);
        cashMoneySplash.Play();
        AudioSource.PlayClipAtPoint(deliverySuccessKaching,Camera.main.transform.position);
        spriteRenderer.color = noPackageColor;
        moneyTracker.MoneyChange(+100);
        Debug.Log("Package Delivered");
        canDeliver=false;
        hasPackage = false;
        coroutineStarted = false;
        yield break;
     }

}
