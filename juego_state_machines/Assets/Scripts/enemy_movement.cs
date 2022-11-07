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
    int hp = 2;
    Animator anims;
    SphereCollider spc;
    //float delay = 0.1f;
    SpriteRenderer spr;
    public LayerMask PlayerLayer;
    public Transform attackPoint;
    public float attackRange;
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
        spc = GetComponentInChildren<SphereCollider>();
        anims = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
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
        anims.SetTrigger("run");
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if (spr.flipX == false && Player.transform.position.x < 0f)
        {
            spr.flipX = true;
        }
    }
    public void SeePlayer()
    {
        yaTeVi = true;
        
    }

    void death()
    {
        anims.SetTrigger("die");
        StopCoroutine(castingPunch());
        speed = 0;
        yaTeVi = false;
        bc.enabled = false;
        spc.enabled = false;
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            death();
        }
    }

    public void punch()
    {
        StartCoroutine(castingPunch());
        yaTeVi = false;

    }
    
    public IEnumerator castingPunch()
    {
        speed = 0;
        anims.SetTrigger("punch");
        yield return new WaitForSeconds(1.5f);
        tryDealDamage();
        anims.SetTrigger("run");
        yaTeVi = true;
        speed = 3;
    }

    void tryDealDamage()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, PlayerLayer);
        foreach (Collider player in hitPlayers)
        {
            player.GetComponent<player_movement>().hp_down();
        }
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}
