using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public Renderer Renderer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Renderer.enabled = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Renderer.enabled =true;
    }
}
