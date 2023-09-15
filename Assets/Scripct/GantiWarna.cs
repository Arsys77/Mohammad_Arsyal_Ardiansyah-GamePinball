using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GantiWarna : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On
   }

    public Collider Bola;
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState state;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola)
        {
            Toggle();
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

}
