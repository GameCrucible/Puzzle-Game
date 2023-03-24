using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public static float offScreen = 10f; // Where offscreen is
    public float speed; //How fast the projectile moves
    private Vector3 target; //Where the projectile is going
    public int dir; //Directions for projectile's trajectory
    public int dmg; //Represents damage of projectile
    public bool directionSwitch; //On for North/South, Off for East/West

    void FixedUpdate()
    {
        if (transform.position.z > offScreen || transform.position.z < -offScreen || transform.position.x > offScreen || transform.position.x < -offScreen)
        {
            Destroy(this.gameObject); //If the projectile is offscreen its deleted
        }

        //Same movement as Enemies, effected by the TimeScript as well
        if (directionSwitch)
        {
            target.Set(transform.position.x, transform.position.y, dir);
        }
        else
        {
            target.Set(dir, transform.position.y, transform.position.z);
        }

        if (TimeStopo.isTimeStopped) { }
        else
        {
            //Find position
            Vector3 direction = target - transform.position;
            direction = direction.normalized * Time.deltaTime * speed;
            float distanceMax = Vector3.Distance(transform.position, target);

            //Movement
            transform.position = (transform.position + Vector3.ClampMagnitude(direction, distanceMax));
        }
        
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collided = coll.gameObject; //Finds object collided with
        print(collided.name);
        if (collided.CompareTag("Enemy") && !collided.CompareTag("Defense")) //Checks if its an enemy
        {
            //If its an enemy it deals damage and the projectile is deleted
            print("hit enemy");
            Destroy(this.gameObject);
            Enemy_Movement enScript = collided.GetComponent<Enemy_Movement>();
            enScript.injured(dmg);
            
        }
    }


}
