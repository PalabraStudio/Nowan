using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformable : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
