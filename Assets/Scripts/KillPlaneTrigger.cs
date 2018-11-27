using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.tag == "Player")
        {
            Debug.Log("Player has collided with the kill plane!");
        }
        

    }
}
