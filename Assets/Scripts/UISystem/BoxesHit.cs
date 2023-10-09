using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class BoxesHit : MonoBehaviour
{
    //Public
    public Text hitsScored; 
    public Image fillBar;
    public GameManager gameManager; 
    public Punch leftController; 
    public Punch rightController; 
    
    //Private
    private float totalBoxCount; 
    private float hitsCount; 

    private void Start()
    {
        //get and display the number of valid hits scored against the boxes.
        hitsScored.text = hitsCount.ToString();
        fillBar.fillAmount = 0f;
        totalBoxCount = gameManager.BoxesInLevel;
    }

    private void OnEnable()
    {
        leftController.OnCubeHit += UpdateUIData;
        rightController.OnCubeHit += UpdateUIData;

    }

    private void OnDisable()
    {
        leftController.OnCubeHit -= UpdateUIData;
        rightController.OnCubeHit += UpdateUIData;

    }

    void UpdateUIData(int hit)
    {
        hitsCount += hit;

        //Show the hits scored on the Diegetic UI.
        hitsScored.text = hitsCount.ToString();
        fillBar.fillAmount = hitsCount / totalBoxCount;


        //Debug.Log($"Fill Bar Fill Amount : { fillBar.fillAmount}");
    }
}
