using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{

    TimeScript ts;

    float scale;
    float speed;

    void Start()
    {
        ts = TimeScript.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if mouse has moved
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if(mouseX != 0 || mouseY != 0)
        {
            scale = 0.5f;
            speed = 10;
        }
        else
        {
            if (Input.anyKey)
            {
                scale = 1;
                speed = 10;
            }
            else
            {
                scale = 0;
                speed = 4;
            }
        }

        ts.timeScale = Mathf.Lerp(ts.timeScale, scale, Time.deltaTime * speed);
    }


}
