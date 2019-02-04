using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnnemi : MonoBehaviour {
    public float speed = 1f;
    private Rigidbody2D rb2d;
    public Vector2 direction;
    public Vector2 mouvement;
    public bool ismoving;
    public GameObject puce;
    public int waiter;
    void Start()
    {
        waiter = 1;
        ismoving = false;
        direction = new Vector2 (0, 0);
        rb2d = GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        if (direction== new Vector2 (0,0) &&(this.GetComponent<CalculateMove>().pathIsReady||this.GetComponent<CalculateMove>().routining))
        {
            puce.SetActive(false); puce.SetActive(true);
        }
        Vector2 mouvement = new Vector2(transform.position.x + direction.x*speed*waiter, transform.position.y + direction.y*speed*waiter);
        rb2d.MovePosition(mouvement);
    }
}
