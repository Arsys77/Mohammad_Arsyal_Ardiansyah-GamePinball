using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomoutController : MonoBehaviour
{
    public Collider Bola;
    public CameraControler cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola)
        {
            cameraController.GoBackToDefault();
        }
    }
}
