using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    //Events
    public event Action<int> OnCubeSpawned = (count) => { };  
    public event Action OnSpawningComplete = () => { }; 

    //Public
    public GameObject[] puchables;
    public float beatsPerMinute = 130;
    public GameManager gameManager;

    //Private
    private float timer = 0f;
    private int cubeSpawnThreshold;// maximum # of cubes you can spawn in one level, based on the value set within the  gameManager 
    private int cubesSpawned; // keeps count of the # of cubes spawn making sure the spawn threshold value is not overshot 
    

    // Have 5 unique lane starting positions for the cubes.
    private float[,] lanePositions =
    {
        {0f,1f, 0 },
        {-0.6f, 1.25f,0 },
        {0.6f, 1.25f,0 },
        {-0.3f, 1,0 },
        {0.03f, 1f,0},
    };

    public Vector3 lane;

    // Start is called before the first frame update
    void Start()
    {
        //Obtain the value of the maximum number of cubes that can be spawned for this level.
        cubeSpawnThreshold = gameManager.BoxesInLevel;
    }

    // Update is called once per frame
    void Update()
    {
        //if you have spawned the alloted number of cubes for the level, don't spawn any more cubes.
        if (cubesSpawned >= cubeSpawnThreshold) 
        {
            OnSpawningComplete(); 
            gameObject.SetActive(false); 
            return;
        }

        timer += Time.deltaTime;

        //Beat interval for creating new cube.
        float beatInterval = (60.0f / beatsPerMinute) * 2f;

        // Cubes appear with beats
        if (timer > beatInterval)
        {
            timer = 0f;
            CreateCube();
            OnCubeSpawned(1);
        }
    }

    void CreateCube()
    {
        if (puchables.Length == 0) return;

        GameObject punchable = new GameObject("cubeHOlder");
        punchable.transform.parent = transform;
        punchable.transform.localPosition = Vector3.zero;
        punchable.transform.localRotation = Quaternion.identity;
        punchable.transform.parent = null;

        CubeMovement cm = punchable.AddComponent<CubeMovement>();
        cm.cubeSpeed = 5f;

        // Instantiate a random cube model (either blue or red)
        int randomCube = UnityEngine.Random.Range(0, puchables.Length);
        GameObject cube = Instantiate(puchables[randomCube]);
        cube.transform.parent = punchable.transform;

        //Cube located in center of parent position
        cube.transform.localPosition = Vector3.zero;

        Vector3 rot = Vector3.zero;
        rot.x = R.Range(0, 360);
        rot.y = R.Range(0, 360);
        rot.z = R.Range(0, 360);
        cube.transform.localRotation = Quaternion.Euler(rot);

        Vector3 spot = transform.position;
        spot.x += R.Range(-1f, 1f) * lane.x;
        spot.y += R.Range(0.2f, 1f) * lane.y;

        punchable.transform.localPosition = spot;
        cm.StartMoving();

        cubesSpawned++; 
    }
}
