using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{

    public float timeDelta;
    public float timeFixed;
    public float timeScale;

    public static TimeScript instance;

    public static TimeScript GetInstance()
    {
        return instance;
    }

 
    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        timeFixed = Time.fixedDeltaTime * timeScale;
    }

    void Update()
    {
        timeDelta = Time.deltaTime * timeScale;
    }
}
