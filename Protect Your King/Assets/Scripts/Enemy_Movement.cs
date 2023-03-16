using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    public Vector3 target;
    public float speed;
    public bool isStunned = false;
    public int health;

    // Update is called once per frame
    void Update()
    {
        if (isStunned == true)
        {

        }
        else { 
        //Find position
        Vector3 direction = target - transform.position;
        direction = direction.normalized * Time.deltaTime * speed;
        float distanceMax = Vector3.Distance(transform.position, target);

        //Movement
        transform.position = (transform.position + Vector3.ClampMagnitude(direction, distanceMax) * TimeScript.GetInstance().timeScale);
         }
    }

    void OnCollisionEnter(Collision coll)
    {
        print("hit");
        GameObject collided = coll.gameObject;
        if (collided.CompareTag("Defense"))
        {
            isStunned = true;
            Invoke("unStun", 1);
            Destroy(collided.gameObject);
        }
    }

    public void injured(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void stun(int stunTime)
    {
        print("stunned");
        isStunned = true;
        Invoke("unStun",stunTime);
    }

    void unStun()
    {
        isStunned = false;
    }
}
