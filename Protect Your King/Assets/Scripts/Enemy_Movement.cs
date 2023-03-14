using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    public Vector3 target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target - transform.position;

        direction = direction.normalized * Time.deltaTime * speed;

        float distanceMax = Vector3.Distance(transform.position, target);
        transform.position = transform.position + Vector3.ClampMagnitude(direction, distanceMax);
    }
}
