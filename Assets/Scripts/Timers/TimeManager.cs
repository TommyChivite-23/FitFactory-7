using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TimeManager : MonoBehaviour
{
    // Singleton Reference
    public static TimeManager instance;

    //Public
    public VelocityEstimator head;
    public VelocityEstimator leftHand;
    public VelocityEstimator rightHand;

    public float sensitivity = 0.8f;
    public float minTimeScale = 0.05f;
    public float slowMoDuration = 10f;

    //Private
    private float initialFixedDeltaTime;
    private float initialTimeScale;

    private float slowMoTick;
    private bool isSlowMoActive;
    
    ActionBasedContinuousMoveProvider playerMotionController;

    Vector3 initialPlayerPosition = Vector3.zero;


    private void Awake()
    {
        if (instance)
            Destroy(gameObject);

        instance = this;
        transform.parent = null;
        DontDestroyOnLoad(gameObject);

        
        playerMotionController = playerMotionController ?? FindObjectOfType<ActionBasedContinuousMoveProvider>();
        initialPlayerPosition = playerMotionController.transform.position;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Slow Motion
        isSlowMoActive = false;
        initialFixedDeltaTime = Time.fixedDeltaTime;
        initialTimeScale = Time.timeScale;

   
        yield return new WaitForSeconds(0.1f);
        DeactivateSlowMo();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isSlowMoActive && Input.GetKeyUp(KeyCode.Space))
        //    TimeManager.instance.ActivateSlowMo();

        if (!isSlowMoActive) return;

        slowMoTick += Time.deltaTime;
        if (slowMoTick > slowMoDuration)
        {
            DeactivateSlowMo();
            return;
        }

        float velocityMagnitude = head.GetVelocityEstimate().magnitude + leftHand.GetVelocityEstimate().magnitude + rightHand.GetVelocityEstimate().magnitude;

        //will claim Velocity value between 0 and 1
        Time.timeScale = Mathf.Clamp01(minTimeScale + velocityMagnitude * sensitivity);

        Time.fixedDeltaTime = initialFixedDeltaTime * Time.timeScale;
    }

    /// <summary>
    /// Entry point 
    /// </summary>
    public void ActivateSlowMo()
    {
        if (isSlowMoActive) return;
        
        isSlowMoActive = true;
        slowMoTick = 0;
        
        playerMotionController.enabled = true;
    }

    public void DeactivateSlowMo()
    {
        isSlowMoActive = false;
        slowMoTick = 0;

        Time.fixedDeltaTime = initialFixedDeltaTime;
        Time.timeScale = initialTimeScale;
        
        playerMotionController.enabled = false;
        
        //Return to initial position
        playerMotionController.transform.position = initialPlayerPosition;
    }
}
