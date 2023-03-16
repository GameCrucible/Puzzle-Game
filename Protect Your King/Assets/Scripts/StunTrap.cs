using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTrap : MonoBehaviour
{
    public int stunTime;
    void OnCollisionEnter(Collision coll)
    {
        GameObject collided = coll.gameObject;
        if (collided.CompareTag("Enemy"))
        {
            Enemy_Movement enScript = collided.GetComponent<Enemy_Movement>();
            enScript.stun(stunTime);
            Destroy(this.gameObject);
        }
    }
}
