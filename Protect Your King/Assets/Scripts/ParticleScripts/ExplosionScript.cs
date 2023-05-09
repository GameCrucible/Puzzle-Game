using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Finish", 2); //Waits 2 seconds for animation to finish
    }

    void Finish()
    {
        Destroy(this.gameObject); //Destroys object to prevent repeats
    }
}
