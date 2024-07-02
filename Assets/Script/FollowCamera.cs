using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    [SerializeField] float topBorder = 20;
    [SerializeField] float bottomBorder= -20;
    [SerializeField] float leftBorder = -20;
    [SerializeField] float rightBorder = 20;

    //This thing's position (Camera) Should follow the car's position
    
    void Update()
    {
    }

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x,leftBorder,rightBorder),transform.position.y,transform.position.z);
    }
}
