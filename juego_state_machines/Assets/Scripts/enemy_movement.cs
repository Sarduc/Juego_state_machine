using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    BoxCollider bc;
    Rigidbody rb;
    GameObject Player;
    public int speed = 6;
    bool yaTeVi = false;
    public int hp = 1;
    Animator anims;
    SphereCollider spc;
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
        spc = GetComponentInChildren<SphereCollider>();
    }

    void Update()
    {
        if (yaTeVi == true)
        {
            MoveToPlayer();
        }
    }

    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    public void SeePlayer()
    {
        yaTeVi = true;
    }

    void death()
    {
        //anims.Play(dying);
        speed = 0;
        yaTeVi = false;
        bc.enabled = false;
        spc.enabled = false;
        Destroy(this.gameObject);

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            death();
        }
    }
}
