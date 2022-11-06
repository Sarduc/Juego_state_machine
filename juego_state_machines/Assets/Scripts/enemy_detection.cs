using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_detection : MonoBehaviour
{
    BoxCollider bc;
    enemy_movement enemy;
    void Start()
    {
        enemy = GetComponentInParent<enemy_movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.tag == "Player")
            {
                Debug.Log("ES EL PLAYER");
                enemy.GetComponentInParent<enemy_movement>().SeePlayer();
            }
        }
        
    }
}
