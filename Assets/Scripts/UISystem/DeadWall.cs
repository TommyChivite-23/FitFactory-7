using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DeadWall : MonoBehaviour
{
    //Events
    public event Action<int> OnCubeMissed = (count) => { };

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Cube : {other.gameObject.name} collided with Dead Wall");

        OnCubeMissed(1);

        // Destroying punchables created in CubeSpawner.
        //Destroy this cube block that slipped away from your punch.
        Destroy(other.gameObject.GetComponentInParent<Rigidbody>().transform.parent.gameObject); 

    }
}
