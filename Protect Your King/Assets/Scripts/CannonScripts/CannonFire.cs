using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    //This code controls the cannon firing

    public GameObject Projectile; //Instatiates the Projectile
    private Vector3 raycastCollision = Vector3.zero; //Creates a raycast so the cannon can find enemies
    public bool isProjectile; //Keeps cannon from firing constantly
    public int fireTime; //determines firing time
    public GameObject explosion;
    public Transform barrel;

    //Use 0.75 for offset
    public float xProjectileOffset; //Controls projectile's offset in the x direction
    public float zProjectileOffset;

    private Vector3 animateScale = new Vector3(0f, 50f, 0f); //Quick animation reference
    private Vector3 animatePos = new Vector3(0f, 0f, 0.5f);

    void Start()
    {
        isProjectile = false; //Sets cannon to be ready to fire
    }
    void FixedUpdate()
    {
        //Sets up Raycast so its always on top of the cannon
        Vector3 detect = transform.TransformDirection(Vector3.forward);
        if(TimeStopo.isTimeStopped) //If time is stopped nothing happens
        {
           
        }
        else
        {
            if (Physics.Raycast(transform.position, detect, 100))
            {
                if (isProjectile == false)
                {
                    isProjectile = true; //Prevents multiple shots from happening at once
                    animateStart(); //Starts cannon animation
                    Invoke("fireCannon", fireTime); //Calls for shot function
                }
            }
        }
            
        

    }

    void animateStart()
    {
        barrel.transform.localPosition -= animatePos;
        barrel.transform.localScale -= animateScale;
    }

    void animateEnd()
    {
        barrel.transform.localPosition += animatePos;
        barrel.transform.localScale += animateScale;
    }

    void fireCannon()
    {
        //Code to fire cannon
        print("spawn");
        GameObject explode = Instantiate<GameObject>(explosion, transform.position, transform.rotation);
        explode.transform.position = new Vector3((transform.position.x + xProjectileOffset), transform.position.y, (transform.position.z + zProjectileOffset));
        GameObject projectile = Instantiate<GameObject>(Projectile); //Spawns cannonball
        projectile.transform.position = new Vector3((transform.position.x + xProjectileOffset),transform.position.y,(transform.position.z + zProjectileOffset));

        animateEnd();

        Invoke("delayFire", 2); //Calls the delay
    }

    void delayFire()
    {
        //Delays cannon fire, not a perfect solution but it works
        isProjectile = false;
    }
}
