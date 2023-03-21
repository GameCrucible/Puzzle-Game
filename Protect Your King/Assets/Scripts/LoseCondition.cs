using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public GameObject manager; //Assigns manager
    public bool dirSwitch; //On = Nort/South, Off = East/West 
    public bool negSwitch; //On = North/East, Off = South/West
    //I know there's a more elegant way to do this, but its 4 am and I don't have the capacity to

    void FixedUpdate()
    {
        if (dirSwitch) {
            if (negSwitch)
            {
                if (this.transform.position.z > -1.3)
                {
                    GameManager manage = manager.GetComponent<GameManager>();
                    manage.lose();
                }
            }
            else
            {
                if (this.transform.position.z < 1.3)
                {
                    GameManager manage = manager.GetComponent<GameManager>();
                    manage.lose();
                }
            }

        }
        else {
            if (negSwitch)
            {
                if (this.transform.position.x > -1.3)
                {
                    GameManager manage = manager.GetComponent<GameManager>();
                    manage.lose();
                }
            }
            else
            {
                if (this.transform.position.x < 1.3)
                {
                    GameManager manage = manager.GetComponent<GameManager>();
                    manage.lose();
                }
            }
        }

    }

    public void directionSwitch()
    {
        negSwitch = !negSwitch;
    }
    
}
