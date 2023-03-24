using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public GameObject manager; //Assigns manager
    //I know there's a more elegant way to do this, but its 4 am and I don't have the capacity to


    void OnCollisionEnter(Collision col)
    {
        GameObject collided = col.gameObject;
        if (collided.CompareTag("Finish"))
        {
            GameManager manage = manager.GetComponent<GameManager>();
            manage.lose();
        }
    }

    
}
