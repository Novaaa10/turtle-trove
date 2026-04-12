using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TurtleGerak : MonoBehaviour
{
    public float speed = 5f;
    public float digSpeed = 3f;

    public Tilemap potionTilemap;
    public Tilemap petiTilemap;
    public Tilemap diamondTilemap;

    public int maxHP = 50;
    public int currentHP;

    public TextMeshProUGUI hpText;

    public float drainInterval = 0.2f; // waktu tiap pengurangan HP
    private float drainTimer;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Gerak kiri kanan
        transform.Translate(new Vector2(move * speed * Time.deltaTime, 0));

        // Gali ke bawah
        bool isDigging = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        if (isDigging)
        {
            transform.Translate(Vector2.down * digSpeed * Time.deltaTime);
        }

        // === HP BERKURANG PELAN ===
        if (Mathf.Abs(move) > 0 || isDigging)
        {
            drainTimer += Time.deltaTime;

            if (drainTimer >= drainInterval)
            {
                currentHP -= 1;
                currentHP = Mathf.Clamp(currentHP, 0, maxHP);

                UpdateHPText();
                drainTimer = 0f;
            }
        }

        CekDiamond();
        CekPotion();
        CekPeti();
    }

    void UpdateHPText()
    {
        hpText.text = currentHP + "/" + maxHP;
    }

    void CekDiamond()
    {
        Vector3 pos = transform.position;

        Vector3[] cekPos = new Vector3[]
        {
            pos,
            pos + new Vector3(0.4f, 0, 0),
            pos + new Vector3(-0.4f, 0, 0),
            pos + new Vector3(0, 0.4f, 0),
            pos + new Vector3(0, -0.4f, 0)
        };

        foreach (Vector3 p in cekPos)
        {
            Vector3Int cell = diamondTilemap.WorldToCell(p);

            if (diamondTilemap.GetTile(cell) != null)
            {
                diamondTilemap.SetTile(cell, null);
                Debug.Log("Diamond keambil!");
            }
        }
    }

    void CekPotion()
    {
        Vector3 pos = transform.position;

        Vector3[] cekPos = new Vector3[]
        {
            pos,
            pos + new Vector3(0.4f, 0, 0),
            pos + new Vector3(-0.4f, 0, 0),
            pos + new Vector3(0, 0.4f, 0),
            pos + new Vector3(0, -0.4f, 0)
        };

        foreach (Vector3 p in cekPos)
        {
            Vector3Int cell = potionTilemap.WorldToCell(p);

            if (potionTilemap.GetTile(cell) != null)
            {
                potionTilemap.SetTile(cell, null);

                currentHP += 10;
                currentHP = Mathf.Clamp(currentHP, 0, maxHP);

                UpdateHPText();

                Debug.Log("HP nambah: " + currentHP);
            }
        }
    }

    void CekPeti()
    {
        Vector3 pos = transform.position;

        Vector3[] cekPos = new Vector3[]
        {
            pos,
            pos + new Vector3(0.4f, 0, 0),
            pos + new Vector3(-0.4f, 0, 0),
            pos + new Vector3(0, 0.4f, 0),
            pos + new Vector3(0, -0.4f, 0)
        };

        foreach (Vector3 p in cekPos)
        {
            Vector3Int cell = petiTilemap.WorldToCell(p);

            if (petiTilemap.GetTile(cell) != null)
            {
                petiTilemap.SetTile(cell, null);
                Debug.Log("Peti dibuka!");
            }
        }
    }
}