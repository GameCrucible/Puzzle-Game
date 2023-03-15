using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{

    public GameObject Projectile;
    public Vector3 raycastCollision = Vector3.zero;

    void Start()
    {
        StartCoroutine(detected());
    }

    void FixedUpdate()
    {
        var detectRay = new Ray(this.transform.position, transform.forward);
        RaycastHit ifHit;
        if (Physics.Raycast(detectRay, out ifHit, 100))
        {
            print("Detected");
            Invoke("detected", 1);
        }
    }

    IEnumerator detected()
    {
        Invoke("Fire", 2);
        yield return new WaitForSeconds(3.0f);
        print("complete");
    }

    void Fire()
    {
        GameObject projectile = Instantiate<GameObject>(Projectile);
        projectile.transform.position = transform.position;
    }
}
