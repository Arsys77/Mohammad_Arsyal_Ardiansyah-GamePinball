using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Efek : MonoBehaviour
{
    public Collider Bola;
    public AudioSource Audio_Source;
    public AudioClip suara;


    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            Audio_Source.PlayOneShot(suara);
        }


    }
}
