using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonrelease;

    private void OnMouseDown()
    {
        mouseButtonrelease = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x  - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonrelease = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string NameGameObject;
        string CollisionGO;

        NameGameObject= gameObject.name.Substring(0, name.IndexOf("_"));
        CollisionGO = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if (mouseButtonrelease && NameGameObject == "Acorn" && NameGameObject == CollisionGO) 
        {
            Instantiate(Resources.Load("Oak_Object"), transform.position, Quaternion.identity);
            mouseButtonrelease= false;
            Destroy(collision.gameObject);

        }

        else if (mouseButtonrelease && NameGameObject == "Oak" && NameGameObject == CollisionGO)
        {
            Instantiate(Resources.Load("Rocket_Object"), transform.position, Quaternion.identity);
            mouseButtonrelease = false;
            Destroy(collision.gameObject);

        }
        
    }
}
