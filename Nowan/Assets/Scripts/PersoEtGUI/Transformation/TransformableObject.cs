using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformableObject : MonoBehaviour {
    public int ID;
    public GameObject Perso;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Perso.GetComponent<Copy>().prochePerso.Add(this.gameObject);
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Perso.GetComponent<Copy>().prochePerso.Remove(this.gameObject);
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
