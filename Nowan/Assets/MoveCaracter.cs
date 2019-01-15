using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { BAT, MOUSE, NORMAL};

public class MoveCaracter : MonoBehaviour {
    public STATE m_state;
    public float speed = 1f;
    private Rigidbody2D rb2d;
    public bool shift;
    public float sprint = 2.5f;
    public float horizontal;
    public float vertical;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    //Les FixedUpdates ne dépendent pas du framerate du pc
    //ce qui permet de rester propre niveau physique peu
    //Importe les performances d'un pc.
    void FixedUpdate()
    {
        shift = Input.GetKey(KeyCode.LeftShift);
        horizontal = Input.GetAxis("Horizontal") ;
        vertical = Input.GetAxis("Vertical") ;

        if (shift)
        {
            horizontal = horizontal * sprint;
            vertical = vertical * sprint;
        }
        else
        {
            horizontal = horizontal * speed;
            vertical = vertical * speed;
        }
        Vector2 mouvement = new Vector2 (transform.position.x + horizontal,transform.position.y + vertical);
        rb2d.MovePosition(mouvement);
    }
    private void OnCollisionEnter2D(Collider2D collision) //Le ccode ne marche pas, il y a une erreur de syntaxe
    {
        if (collision.tag == "mouseHole" && m_state == STATE.MOUSE)
        {
            collision.enabled = false;
        }
        else if (m_state == STATE.BAT)
        {
            collision.enabled = false;
        }
    }

    private void OnCollisionExit2D(Collider2D collision)
    {
        if (collision.tag == "mouseHole" && m_state == STATE.MOUSE)
        {
            collision.enabled = true;
        }
        else if (m_state == STATE.BAT)
        {
            collision.enabled = true;
        }
    }
}
