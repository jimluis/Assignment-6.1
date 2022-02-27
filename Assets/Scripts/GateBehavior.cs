using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.BroadcastMessage("OpenGate");
            Debug.Log("Player has entered the trigger zone");
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited the trigger zone");
            gameObject.BroadcastMessage("CloseGate");
        }
    }


}
