using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTrap : MonoBehaviour
{
    public int stunTime; //Can be set
    void OnCollisionEnter(Collision coll)
    {
        //If Enemy collides with this object its stunned for a time based on the object
        GameObject collided = coll.gameObject; 
        if (collided.CompareTag("Enemy"))
        {
            Enemy_Movement enScript = collided.GetComponent<Enemy_Movement>();
            enScript.stun(stunTime);
            Destroy(this.gameObject);
        }
    }
}
