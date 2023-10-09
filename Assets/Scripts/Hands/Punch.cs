using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction;

public class Punch : MonoBehaviour
{
    //Events
    public event Action<int> OnCubeHit = (count) => { }; 
    public event Action<string> OnCubeHitHaptics = (hand) => { };

    [SerializeField] private Haptics haptic;

    //Public
    public LayerMask layer; 
    
    //Private
    private Vector3 previousPosn = Vector3.zero; 
    private string interactor; 

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f, layer))
        {
            Vector3 dirVector = transform.position - previousPosn;

            //Vector3.Angle() requires 2 directional vectors as input to yield an angle value, which will always be limited to 180 degrees
            if (Vector3.Angle(dirVector, hit.transform.up) > 110f) 
            {
                // Check whether hit is a powerup.
                Debug.Log(hit.transform.name);
                PowerUp powerUp = hit.transform.gameObject.GetComponent<PowerUp>();
                if (powerUp)
                {
                    // Future: apply logic based on the type of power up.
                    switch (powerUp.type)
                    {
                        case PowerType.SlowMo:

                            // Activate slow motion.
                            TimeManager.instance?.ActivateSlowMo();
                            break;
                    }
                }
                else
                {
                    OnCubeHit(1);
                }

                // Check if hit object has audio and play.
                SFXUnit sfxUnit = hit.transform.GetComponent<SFXUnit>();
                if (sfxUnit)
                    AudioManager.OnPlaySFX?.Invoke(sfxUnit.clip);

                // Destroying punchables created in CubeSpawner.
                Destroy(hit.transform.parent.gameObject);
                
                haptic.SendHapticImpulse();
            }

        }

        previousPosn = transform.position;

    }

}
