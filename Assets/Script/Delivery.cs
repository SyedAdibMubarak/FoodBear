using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);  
    [SerializeField] float destroyDelay = 1f;
    [SerializeField] ParticleSystem cashMoneySplash;
    [SerializeField] AudioClip deliverySuccessKaching;
    [SerializeField]  bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    
   

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
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
            Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "Customer" && hasPackage)
        {
            cashMoneySplash.Play();
            AudioSource.PlayClipAtPoint(deliverySuccessKaching,Camera.main.transform.position);
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package Delivered");
            hasPackage = false;
        }
    }
}
