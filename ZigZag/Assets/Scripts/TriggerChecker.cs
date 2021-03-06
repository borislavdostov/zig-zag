﻿using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    //The diamond on the platform
    private GameObject diamond;

    void OnTriggerEnter(Collider col)
    {
        //If the platform spawn diamond, we get the instance of that diamond
        if (col.CompareTag("Diamond"))
        {
            diamond = col.gameObject;
        }
    }

    //Automatically called when whenever object comes out from the trigger
    //Collider col is the object htat collides and exits the trigger
    void OnTriggerExit(Collider col)
    {
        //Get the tag of the collider and check if its the ball
        if (col.CompareTag("Ball"))
        {
            //Call function after a time (name of the function, seconds)
            Invoke("FallDown", 0.5f);

            //If we have diamond on the platform, we make the diamond falls
            if (diamond != null)
            {
                diamond.GetComponent<BoxCollider>().isTrigger = false;
                diamond.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    void FallDown()
    {
        //Get Platform from TriggerChecker and set gravity to the platform to true
        GetComponentInParent<Rigidbody>().useGravity = true;
        //Help the platforms to fall down, after we set useGravity to true
        GetComponentInParent<Rigidbody>().isKinematic = false;
        //Destroy the parent platform object(gameObject, after how many seconds to be destroyed)
        Destroy(transform.parent.gameObject, 2f);
    }
}
