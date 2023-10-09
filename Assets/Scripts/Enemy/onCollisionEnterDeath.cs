using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionEnterDeath : MonoBehaviour
{
    //Public
    public string targetTag;
    public Enemy enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == targetTag)
        {
            enemy.Dead(collision.contacts[0].point);
        }
    }
}
