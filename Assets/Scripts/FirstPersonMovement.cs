using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FirstPersonMovement : MonoBehaviour
{

    public Vector3 direction;
    public float speed;
    public Rigidbody rb; // Playe's rigidBody

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Make world direction into local direction
        Vector3 newDirection = transform.TransformDirection(direction);
        //Debug.Log("FirstPersonMovement - Update");
        //transform.Translate(direction * speed * Time.deltaTime);

        //move using physics
        rb.MovePosition(rb.position + (newDirection * speed * Time.deltaTime));
    }

    //OnPLayerMove event handler
    public void OnPlayerMove(InputValue value)
    {
        //A vector with x and y components corresponding to the player's QASD and arrow inputs
        //both components are in the range [1, -1]
        //Debug.Log("FirstPersonMovement - OnPlayerMove");

        Vector2 inputVector = value.Get<Vector2>();
        //direction = new Vector3(inputVector.x, 0, inputVector.y);

        //move in the xyz-plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;

    }
}
