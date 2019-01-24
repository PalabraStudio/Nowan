using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { BAT, MOUSE, NORMAL};

public class MoveCaracter : MonoBehaviour {

    public float speed;
    public float sprint;

    public Rigidbody2D rb2d;
    public Animator animator;

    private bool m_shift; //Touche shift appuyée ou pas
    public bool shift { get { return m_shift; } }
    private float m_horizontal;
    public float horizontal { get { return m_horizontal; } }
    private float m_vertical;
    public float vertical { get { return m_vertical; } }

    private bool p_up, p_down, p_left, p_right; //en travaux
    private bool up, down, left, right;

    //Les FixedUpdates ne dépendent pas du framerate du pc
    //ce qui permet de rester propre niveau physique peu
    //Importe les performances d'un pc.
    void FixedUpdate()
    {
        m_shift = Input.GetKey(KeyCode.LeftShift);
        m_horizontal = Input.GetAxis("Horizontal") ;
        m_vertical = Input.GetAxis("Vertical") ;

        
        animator.SetBool("up", (m_vertical>0) && (m_horizontal==0));
        animator.SetBool("down", (m_vertical<0) && (m_horizontal == 0));
        animator.SetBool("left", m_horizontal<0);
        animator.SetBool("right", m_horizontal>0);



        if (m_shift)
        {
            m_horizontal = m_horizontal * sprint;
            m_vertical = m_vertical * sprint;
        }
        else
        {
            m_horizontal = m_horizontal * speed;
            m_vertical = m_vertical * speed;
        }
        Vector2 mouvement = new Vector2 (transform.position.x + m_horizontal,transform.position.y + m_vertical);
        rb2d.MovePosition(mouvement);

        
    }
}
