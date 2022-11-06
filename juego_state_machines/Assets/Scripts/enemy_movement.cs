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
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
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
}
