using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_yeah : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float roomSize = 10;
    [SerializeField] private float camSpeed = 50;

    void Update()
    {
        Vector3 targetPos = new Vector3(roomSize * .5f + Mathf.Floor(target.position.x / roomSize) * roomSize, target.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * camSpeed);
    }
}
