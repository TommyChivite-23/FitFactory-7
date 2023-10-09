using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Haptics : MonoBehaviour
{
    public ActionBasedController controller;
    public float amplitude = 1.0f;
    public float duration = 0.5f;


    //--------

    private void Awake()
    {
        controller = controller ?? GetComponent<ActionBasedController>();
    }

    public void SendHapticImpulse()
    {
        controller.SendHapticImpulse(amplitude, duration);
    }
}
