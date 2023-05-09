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

    //Use 0.75 for offset
    public float xProjectileOffset; //Controls projectile's offset in the x direction

    private Vector3 animateScale = new Vector3(0f, 0f, 0.25f); //Quick animation reference

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
                    this.transform.localScale -= animateScale; //Starts cannon animation
                    Invoke("fireCannon", fireTime); //Calls for shot function
                }
            }
        }
            
        

    }

    void fireCannon()
    {
        //Code to fire cannon
        print("spawn");
        GameObject explode = Instantiate<GameObject>(explosion, transform.position, transform.rotation);
        explode.transform.position = new Vector3((transform.position.x + xProjectileOffset), transform.position.y, (transform.position.z));
        GameObject projectile = Instantiate<GameObject>(Projectile); //Spawns cannonball
        projectile.transform.position = new Vector3((transform.position.x + xProjectileOffset),transform.position.y,(transform.position.z));
        this.transform.localScale += animateScale; //Finishes cannon animation
        Invoke("delayFire", 2); //Calls the delay
    }

    void delayFire()
    {
        //Delays cannon fire, not a perfect solution but it works
        isProjectile = false;
    }
}
