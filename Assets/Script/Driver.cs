using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float BoostSpeed = 20f;

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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            Debug.Log("You Are Boosting");
            moveSpeed = BoostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bump")
        {
            moneyTracker.MoneyChange(-20);
        }
    }
}
