using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnnemi : MonoBehaviour {


    public bool up, down, left, right;

    public Animator animator;
    public float speed;
    public float sprint;
    private float currentsp;
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
        puce = this.transform.Find("Puce").gameObject;
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        if (direction== new Vector2 (0,0) &&(this.GetComponent<CalculateMove>().pathIsReady||this.GetComponent<CalculateMove>().routining))
        {
            puce.SetActive(false); puce.SetActive(true);
        }
        if(GetComponent<CalculateMove>().lastKnownPNode!= null)
        {
            currentsp = sprint;
        }
        else
        {
            currentsp = speed;
        }
        Vector2 mouvement = new Vector2(transform.position.x + direction.x*currentsp*waiter, transform.position.y + direction.y*currentsp*waiter);
        rb2d.MovePosition(mouvement);

        //Debug.Log(direction.x);
        up = (direction.y > 0) && (direction.x == 0);
        down = (direction.y < 0) && (direction.x == 0);
        left = direction.x < 0;
        right = direction.x > 0;
        animator.SetBool("Up", up);
        animator.SetBool("Down", down);
        animator.SetBool("Left", left);
        animator.SetBool("Right", right);

    }
}
