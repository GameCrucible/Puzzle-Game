using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShot_EastWest : MonoBehaviour
{
    public static float offScreen = 5f;
    public float speed;
    public Vector3 target;
    public int dirX; //Directions the cannon ball will go for travel purposes [Screw you Emily] (Please remove insult later)
    public int dmg; //Represents damage of projectile

    void FixedUpdate()
    {
        if (transform.position.z > offScreen)
        {
            Destroy(this.gameObject);
        }

        target.Set(dirX, transform.position.y, transform.position.z);
        //Find position
        Vector3 direction = target - transform.position;
        direction = direction.normalized * Time.deltaTime * speed;
        float distanceMax = Vector3.Distance(transform.position, target);

        //Movement
        transform.position = (transform.position + Vector3.ClampMagnitude(direction, distanceMax) * TimeScript.GetInstance().timeScale);
    }

    void OnCollisionEnter(Collision coll)
    {
        print("collision");
        GameObject collided = coll.gameObject;
        if (collided.CompareTag("Enemy"))
        {
            Enemy_Movement enScript = collided.GetComponent<Enemy_Movement>();
            enScript.injured(dmg);
            Destroy(this.gameObject);
        }
    }

}