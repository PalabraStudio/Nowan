using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformableObject : MonoBehaviour {
    public int ID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
