using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_script : MonoBehaviour
{
    public Collider Bola;
    public float multiplier;
    public Material material;
    public AudioSource Audio_Efek;
    public AudioClip bumper;
    public ScoreManager scoreManager;
    public float score;
    public Color normalColor;
    public Color colideColor; // Warna saat bertabrakan
    private Renderer objectRenderer;
    public VXManager VX;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = normalColor; // Mengatur warna awal objek
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = Bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            animator.SetTrigger("Hit");
            Audio_Efek.PlayOneShot(bumper);

            VX.PlayVFX(collision.transform.position);
            scoreManager.AddScore(score);

            StartCoroutine(ChangeColorAndRestore());
        }
    }

    private IEnumerator ChangeColorAndRestore()
    {
        objectRenderer.material.color = colideColor; // Mengubah warna saat bertabrakan

        yield return new WaitForSeconds(0.1f); // Waktu penahanan warna

        objectRenderer.material.color = normalColor; // Mengembalikan warna normal
    }
}
