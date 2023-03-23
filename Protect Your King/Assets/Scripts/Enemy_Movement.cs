using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    public Vector3 target; //Sets target for the Enemy
    public float speed; //Sets how fast the Enemy is moving
    public bool isStunned = false; //Checks for if the enemy is currently stunned
    public int health; //Gives the Enemy a health bar
    public GameObject manager; //Assign the scene's Game Manager

    // Update is called once per frame
    void Update()
    {
        if (isStunned|| TimeStopo.isTimeStopped)
        {
            //If stunned they can't act
        }
        else { 
        //Find position
        Vector3 direction = target - transform.position;
        direction = direction.normalized * Time.deltaTime * speed;
        float distanceMax = Vector3.Distance(transform.position, target);

        //Movement, affected by TimeScript
        transform.position = (transform.position + Vector3.ClampMagnitude(direction, distanceMax));
         }
    }

    void OnCollisionEnter(Collision coll)
    {
        //This code allows enemies to destroy defenses they make contact with
        GameObject collided = coll.gameObject; //Finds object collided with
        if (collided.CompareTag("Defense")) //Makes sure object is a defense
        {
            stun();
            Destroy(collided.gameObject); //Destroys defense
        }
    }

    public void injured(int damage)
    {
        health -= damage; //Takes damage based on what projectile hit it
        if(health < 1) //Only is destroyed when hit points reach 0
        {
            GameManager manage = manager.GetComponent<GameManager>();
            manage.enemyDefeated();
            Destroy(this.gameObject);
        }
    }

    void unStun()
    {
        isStunned = false; //Unstuns after delay determined by Invoke
    }
    public void stun()
    {
        isStunned = true;
        Invoke("unStun", 1);
    }
}
