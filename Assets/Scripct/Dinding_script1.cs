using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dinding_script1 : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider Bola;
    public float multiplier;
    public ScoreManager scoreManager;
    public float score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = Bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            scoreManager.AddScore(score);

        }

    }
}
