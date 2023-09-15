using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool Lvl_berakhir = false;
    public GameObject MunculGameOver;
    public GameObject HapusBola;
    public GameObject HapusBG;
    public Collider Bola;
    public GameObject GameOver_Efek;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            if (Lvl_berakhir)
            {
                Muncul();

            }
            else
            {
                Berhenti();
            }

            HapusBola.SetActive(false);
            HapusBG.SetActive(false);
 

        }


    }

    public void Berhenti()
    {
        MunculGameOver.SetActive(true);
        GameOver_Efek.SetActive(true);
    }


    public void Muncul()
    {
        MunculGameOver.SetActive(false);
        GameOver_Efek.SetActive(false);
    }
}
