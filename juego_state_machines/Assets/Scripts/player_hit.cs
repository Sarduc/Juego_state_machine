using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hit : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask EnemyLayer;
    public LayerMask ItemLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            melee();
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
        
        Collider[] hitCajas = Physics.OverlapSphere(attackPoint.position, attackRange, ItemLayer);

        foreach (Collider box in hitCajas)
        {
            Caja c = box.GetComponent<Caja>();
            if (c)
            {
                c.takeBoxDamage(1);
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
