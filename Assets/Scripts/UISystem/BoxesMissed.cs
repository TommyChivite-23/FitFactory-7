using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesMissed : MonoBehaviour
{
    //Public 
    public Text hitsMissed; 
    public Image fillBar; 
    public DeadWall deadWall; 
    public GameManager gameManager;

    //Private
    private float totalBoxCount;
    private float missedhits;  

    private void Start()
    {
        //get and display the number of missed or incorrect hits 
        hitsMissed.text = missedhits.ToString(); 
        fillBar.fillAmount = 0f; 
        totalBoxCount = gameManager.BoxesInLevel;
    }

    private void OnEnable()
    {
        //The moment a cube encounters the DeadWall, update the UI Text and fill bar for Hits Missed.
        deadWall.OnCubeMissed += UpdateUIData; 
    }

    private void OnDisable()
    {
        deadWall.OnCubeMissed -= UpdateUIData;
    }

    void UpdateUIData(int missed)
    {
        missedhits += missed;

        //Show the count of missed or incorrect hits on the UI.
        hitsMissed.text = missedhits.ToString();
        fillBar.fillAmount = missedhits / totalBoxCount;


        //Debug.Log($"Fill Bar Fill Amount : { fillBar.fillAmount}");

    }
}
