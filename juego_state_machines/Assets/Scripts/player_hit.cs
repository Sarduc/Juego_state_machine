using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hit : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask EnemyLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            melee();
            Debug.Log("click");
        }
    }

    void melee()
    {
        //anim.SetTrigger("Attack");
       Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, EnemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("PUM PIÑAZO");
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
