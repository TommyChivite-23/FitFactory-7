using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        onCollisionEnterDeath death = other.GetComponent<onCollisionEnterDeath>();

        if(death != null)
        {
            if (death != null)
            {
                death.enemy.Dead(transform.position);
            }
        }
        
    }
}
