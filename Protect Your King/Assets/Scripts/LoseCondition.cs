using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public GameObject manager; //Assigns manager
    public bool negSwitch; //On = North/East, Off = South/West
    private double target = 1.3;
    //I know there's a more elegant way to do this, but its 4 am and I don't have the capacity to
    void Start(){
        if (negSwitch)
        {
            target = -target;
        }
        }
    void FixedUpdate()
    {

            if (target < 0)
            {
                if (this.transform.position.x > target)
                {
                    GameManager manage = manager.GetComponent<GameManager>();
                    manage.lose();
                }
            }
            else
            {
                if (this.transform.position.x < target)
                {
                    GameManager manage = manager.GetComponent<GameManager>();
                    manage.lose();
                }
            }

    }

    public void directionSwitch()
    {
        target = -target;
    }
    
}
