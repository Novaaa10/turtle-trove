using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanukiEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float waktuGanti = 5f; // 5 detik

    public int damage = 5;

    private float timer;
    private int arah = 1; // 1 = kanan, -1 = kiri
    private Vector3 scaleAwal;

    void Start()
    {
        scaleAwal = transform.localScale;
    }

    void Update()
    {
        // Gerak terus
        transform.Translate(Vector2.right * arah * speed * Time.deltaTime);

        // Timer jalan
        timer += Time.deltaTime;

        // Kalau sudah 5 detik → balik arah
        if (timer >= waktuGanti)
        {
            arah *= -1; // balik arah
            timer = 0f;
        }

        // Flip arah
        if (arah > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(scaleAwal.x), scaleAwal.y, scaleAwal.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(scaleAwal.x), scaleAwal.y, scaleAwal.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoleGerak player = collision.GetComponent<MoleGerak>();

            if (player != null)
            {
                player.KenaDamage(damage);
            }
        }
    }
}