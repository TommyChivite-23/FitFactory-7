using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownController : MonoBehaviour
{
    public static Action OnCountDownDone;

    // count down values to display. First ensure that all these count down objects are deactivated in the hierarchy. Also ensure that the CubeSpawner and PlayerHUD game objects are deactivated in the hierarchy. 
    public GameObject[] countDownObject;
    public GameObject cubeSpawner; 
    public GameObject playerHUD; 
    /// <summary>
    ///  -EnemySpawner
    ///  
    ///  
    /// </summary>

    private int countDown = 3;

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }


    IEnumerator CountDown()
    {
        while (countDown >= 0)
        {
            countDownObject[countDown].SetActive(true);

            yield return new WaitForSeconds(1f);

            countDownObject[countDown].SetActive(false);

            countDown--;
        }

        //Activating playerHUD and cubespawner
        playerHUD.SetActive(true); 

        cubeSpawner.SetActive(true);

        OnCountDownDone?.Invoke();

    }

}
