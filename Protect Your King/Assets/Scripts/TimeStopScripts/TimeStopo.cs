using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopo : MonoBehaviour
{
    private bool used = true; //Switch for if there's a timestop available
    public static bool isTimeStopped = false; //Switch so other scripts know if time is stopped

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && used) //Spacebar makes time stop
        {
            used = false;
            isTimeStopped = true;
        }
        if (Input.GetMouseButtonUp(0) && isTimeStopped) //Only activates when time is stopped, ends time stop
        {
            isTimeStopped = false;
        }
    }

}
