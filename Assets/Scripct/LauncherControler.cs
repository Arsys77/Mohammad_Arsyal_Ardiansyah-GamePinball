using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControler : MonoBehaviour
{
    public Collider Bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    public Color normalColor; // Warna normal objek
    public Color pressedColor; // Warna saat tombol ditekan

    private bool isHold;
    private Renderer objectRenderer; // Komponen Renderer objek

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = normalColor; // Mengatur warna awal objek
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == Bola)
        {
            ReadInput(Bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
            objectRenderer.material.color = pressedColor; // Mengubah warna saat tombol ditekan
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        objectRenderer.material.color = normalColor; // Mengembalikan warna normal setelah tombol dilepas
    }
}

