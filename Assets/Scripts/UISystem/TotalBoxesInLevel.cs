using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalBoxesInLevel : MonoBehaviour
{
    //Public
    public Text boxesInLevel; 
    public Image fillBar; 
    public GameManager gameManager; 
    public CubeSpawner cubeSpawner; 

    //Private
    private float totalBoxCount; 
    private float boxesSpawned;

    // Start is called before the first frame update
    void Start()
    {
        //get and display the count of total boxes available for this level
        totalBoxCount = gameManager.BoxesInLevel;
        boxesInLevel.text = totalBoxCount.ToString(); 
        fillBar.fillAmount = 1.0f; 
    }

    private void OnEnable()
    {
        cubeSpawner.OnCubeSpawned += UpdateUIData;
    }

    private void OnDisable()
    {
        cubeSpawner.OnCubeSpawned -= UpdateUIData;
    }

    void UpdateUIData(int boxCount)
    {
        boxesSpawned += boxCount;

        //Show the remaining Boxes left to spawn on the Diegetic UI.
        boxesInLevel.text = (totalBoxCount - boxesSpawned).ToString();
        fillBar.fillAmount = 1.0f - (boxesSpawned / totalBoxCount);


        //Debug.Log($"Fill Bar Fill Amount : { fillBar.fillAmount}");

    }
}
