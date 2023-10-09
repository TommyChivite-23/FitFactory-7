using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float cubeSpeed = 0.2f; 

    private Vector3 movement;

    private bool canMove = false;


    void Start()
    {
        //movement = new Vector3(cubeSpeed, 0f, 0f); 

    }

    void Update()
    {
        //Moves the cube along the X axis
        //transform.Translate(movement * Time.deltaTime); 

        if (!canMove) return;

        transform.position += (transform.forward.normalized * Time.deltaTime * cubeSpeed);
    }

    public void StartMoving()
    {
        canMove = true;
    }

}
