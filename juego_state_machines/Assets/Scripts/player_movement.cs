using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    int speed = 5;
    int verspeed = 3;
    int hp = 3;
    BoxCollider bc;
    Animator animator;

    void Start()
    {
        bc = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        float HorInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * HorInput * Time.deltaTime);
        float VerInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verspeed * VerInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("run");
        }

        if (!Input.anyKey)
        {
            animator.SetTrigger("idle");
        }
    }

    void hp_down()
    {
        hp = hp - 1; 
    }
}
