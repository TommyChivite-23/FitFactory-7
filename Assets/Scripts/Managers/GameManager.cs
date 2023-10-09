using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Public
    public  int boxesInLevel = 100; 
    public CubeSpawner cubeSpawner; 

    
    public int BoxesInLevel => boxesInLevel; 

    //Private
    private int cubeCount;  
    private bool allCubesSpawned = false;

    private void OnEnable()
    {
        cubeSpawner.OnSpawningComplete += AllCubesInLevelSpawned;
    }

    private void OnDisable()
    {
        cubeSpawner.OnSpawningComplete -= AllCubesInLevelSpawned;
    }

    //Update is called before the first frame 
    void Update()
    {
        //You dont need to unnecessarily count the number of cubes in the level each Update if all Cubes have not been spawned yet.
        if (!allCubesSpawned) 
            return;

        //Find out if there are any active cubes in the level.
        cubeCount = GameObject.FindGameObjectsWithTag("Cube").Length;

        //if no active Cube in the level, raise  the OnLevelComplete event.
        if (cubeCount <= 0) 
        {
            OnLevelComplete();
        }

    }


    void AllCubesInLevelSpawned()
    {
        allCubesSpawned = true;
    }

    void OnLevelComplete()
    {

        Debug.Log("LEVEL, COMPLETED");

    }

}

