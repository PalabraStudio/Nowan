using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedDoor : MonoBehaviour
{
    public Renderer Renderer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
            Renderer.enabled = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
            Renderer.enabled = false;
    }
}
