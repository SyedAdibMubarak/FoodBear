using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float accelSpeed = 0.1f;
    [SerializeField] float speedlimit = 20f;
    [SerializeField] float baseSpeed = 20f;

    MoneyTracker moneyTracker;
    // Start is called before the first frame update
    void Start()
    {
        moneyTracker =FindObjectOfType<MoneyTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
        Acceleration();
    }

    void Acceleration(){
        if(Input.GetKey(KeyCode.Space))
        {
            while(moveSpeed<speedlimit)
            {
                moveSpeed+=accelSpeed;
            }
        }
        else
        {
            while(moveSpeed>baseSpeed)
            {
                moveSpeed-=accelSpeed;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bump")
        {
            moneyTracker.MoneyChange(-20);
        }
    }
}
