﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    int speed = 12;
    int verspeed = 3;
    int hp = 3;
    BoxCollider bc;
    Animator animator;
    SpriteRenderer spr;
    [SerializeField] GameObject claw;
    [SerializeField] Transform front;
    [SerializeField] Transform back;

    void Start()
    {
        bc = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement();
        clawCorrect();
    }

    void movement()
    {
        float HorInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * HorInput * Time.deltaTime);
        float VerInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verspeed * VerInput * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            animator.SetTrigger("run");
        }

        if (!Input.anyKey)
        {
            animator.SetTrigger("idle");
        }

        if (HorInput < 0)
        {
            spr.flipX = true;
        }
        if (HorInput > 0)
        {
            spr.flipX = false;
        }
    }

    void clawCorrect()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            claw.transform.position = back.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            claw.transform.position = front.transform.position;
        }
    }

    public void hp_down()
    {
        hp = hp - 1;
        animator.SetTrigger("hurt");
        StartCoroutine(pain());
    }

    public IEnumerator pain()
    {
        speed = 0;
        yield return new WaitForSeconds(0.5f);
        speed = 6;

    }
}
