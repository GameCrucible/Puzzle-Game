using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunManager : MonoBehaviour
{

    private Rigidbody body;
    public GameObject destination;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void stun(int stunTime)
    {
        Enemy_Movement enScript = this.GetComponent<Enemy_Movement>();
        enScript.stun();
        transform.position = new Vector3(destination.transform.position.x, this.transform.position.y, destination.transform.position.z);
    }


}
