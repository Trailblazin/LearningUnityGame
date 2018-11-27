using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Once a rigidbody collides with this objects collider, invoke the LevelGenerator methods
        LevelGenerator.instance.AddChunk();
        LevelGenerator.instance.RemoveOldestChunk();
    }
}
