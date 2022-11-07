using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_punching : MonoBehaviour
{
    SphereCollider spr;
    void Start()
    {
        spr = GetComponent<SphereCollider>(); 
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<enemy_movement>().punch();
            }
        }

    }
}
