using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    //This code controls the cannon firing

    public GameObject Projectile; //Instatiates the Projectile
    public Vector3 raycastCollision = Vector3.zero; //Creates a raycast so the cannon can find enemies
    public bool isProjectile; //Keeps cannon from firing constantly
    public int fireTime; //determines firing time

    //Use 0.75 for offset
    public float xProjectileOffset; //Controls projectile's offset in the x direction
    public float zProjectileOffset; //Controls projectile's offsetr in the z direction

    private Vector3 animateScale = new Vector3(0f, 0f, 0.5f); //Quick animation reference
    private Vector3 lastMousePosition; //Helps detect if the mouse is moving so cannon doesn't fire outside of time

    void Start()
    {
        isProjectile = false; //Sets cannon to be ready to fire
        lastMousePosition = Input.mousePosition; //Sets mouse position
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
        GameObject projectile = Instantiate<GameObject>(Projectile); //Spawns cannonball
        projectile.transform.position = new Vector3((transform.position.x + xProjectileOffset),transform.position.y,(transform.position.z + zProjectileOffset));
        this.transform.localScale += animateScale; //Finishes cannon animation
        Invoke("delayFire", 3); //Calls the delay
    }

    void delayFire()
    {
        //Delays cannon fire, not a perfect solution but it works
        isProjectile = false;
    }
}
