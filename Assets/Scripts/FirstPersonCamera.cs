﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    //The camera attached to the player
    public Camera playerCamera;

    //Container variable for the mouse delta values each grame
    public float deltaX;
    public float deltaY;

    //Container variales for the plauer's rotatation around the x and y axis
    public float xRot; //rotation around the x-axis in degrees
    public float yRot; //rotation around the y-axis in degrees

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;//set player camera
        Cursor.visible = false; //hide the cursor
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keep track of the player's x and y rotation
        yRot += deltaX;
        xRot -= deltaY;

        //Keep the player's rotation clamped to [-90, 90]
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //rotate the camera around the x-axis
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    //OnCameraLook event handler
    public void OnCameraLook(InputValue values)
    {
        //write code to handle the event
        Debug.Log("OnCameraLook");
        //reading the mouse deltas as a vector2 (delta x is the x component and delta y is the y component)
        Vector2 inputVector = values.Get<Vector2>();
        deltaX = inputVector.x;// * Time.deltaTime;
        deltaY = inputVector.y;// * Time.deltaTime;

    }
}
