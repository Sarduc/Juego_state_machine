using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    int hpCajistico = 1;
    bool isOpen = false;
    [SerializeField] Sprite closed;
    [SerializeField] Sprite open;
    SpriteRenderer Spr;
    BoxCollider BC;
    [SerializeField] GameObject medkit;
    void Start()
    {
        BC = GetComponent<BoxCollider>();
        Spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void takeBoxDamage(int damage)
    {
        hpCajistico -= damage;
        if (hpCajistico <= 0)
        {
            cajaMuerte();
        }
    }
    void cajaMuerte()
    {
        Spr.sprite = open;
        BC.enabled = false;
        Instantiate(medkit, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
