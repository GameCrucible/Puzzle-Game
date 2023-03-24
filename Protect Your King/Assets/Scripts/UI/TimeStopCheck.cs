using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStopCheck : MonoBehaviour
{
    public Text txt;
    // Update is called once per frame

    void Update()
    {
        if (TimeStopo.isTimeStopped)
        {
            txt.text = "Time Stop: Used";
        }
    }

}
