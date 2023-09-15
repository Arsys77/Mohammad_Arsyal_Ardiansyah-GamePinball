using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Collider Bola;
    public CameraControler cameraController;
    public float length;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola)
        {
            cameraController.FollowTarget(Bola.transform, length);
        }
    }
}
