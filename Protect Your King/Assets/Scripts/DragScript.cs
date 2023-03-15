using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 findMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnMouseDown()
    {
    mousePosition = gameObject.transform.position - findMouse();
    }

    private void OnMouseDrag()
    {
        transform.position = findMouse() + mousePosition;
    }
}
