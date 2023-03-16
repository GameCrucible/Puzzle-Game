using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{

    public GameObject Projectile;
    public Vector3 raycastCollision = Vector3.zero;
    public bool isProjectile;
    private Vector3 animateScale = new Vector3(0f, 0f, 0.5f);

    void Start()
    {
        isProjectile = false;
    }
    void FixedUpdate()
    {
        Vector3 detect = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, detect, 100))
        {
            if(isProjectile == false)
            {
                print("fire");
                isProjectile = true;
                this.transform.localScale -= animateScale;
                Invoke("fireCannon", 2);
            }
        }

    }

    void fireCannon()
    {
        GameObject projectile = Instantiate<GameObject>(Projectile);
        projectile.transform.position = transform.position;
        this.transform.localScale += animateScale;
        Invoke("delayFire", 3);
    }

    void delayFire()
    {
        isProjectile = false;
    }
}
