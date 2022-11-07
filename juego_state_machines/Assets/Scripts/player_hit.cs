using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hit : MonoBehaviour
{
    public Animator animator;
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
        animator.SetTrigger("atack");
       Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, EnemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("PUM PIÑAZO");
            enemy.GetComponent<enemy_movement>().TakeDamage(1);
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
