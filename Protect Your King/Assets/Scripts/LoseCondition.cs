using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    void FixedUpdate()
    {
        if(this.transform.position.x < 0.1)
        {
            print("You lose");
        }
    }
}
