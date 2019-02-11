using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewStarting : MonoBehaviour
{
    public enum cote { up,down,left,right}
    public cote choix;
    public float waiter;
    public bool test = true;
    // Start is called before the first frame update
    void Start()
    {

        if (choix ==cote.up)
        {
            GetComponentInChildren<Raycast>().dup = 1f;
        }
        if (choix == cote.down)
        {
            GetComponentInChildren<Raycast>().ddown = 1f;
        }
        if (choix == cote.left)
        {
            GetComponentInChildren<Raycast>().dleft = 1f;
        }
        if (choix == cote.right)
        {
            GetComponentInChildren<Raycast>().dright = 1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (waiter > 0)
        {
            waiter -= Time.deltaTime;
        }
        else if(test)
        {
            test = false;
            if (choix == cote.up)
            {
                GetComponentInChildren<Raycast>().dup = 1f;
                GetComponent<Animator>().SetBool("Up", true);
            }
            if (choix == cote.down)
            {
                GetComponentInChildren<Raycast>().ddown = 1f;
                GetComponent<Animator>().SetBool("Down", true);
            }
            if (choix == cote.left)
            {
                GetComponentInChildren<Raycast>().dleft = 1f;
                GetComponent<Animator>().SetBool("Left", true);
            }
            if (choix == cote.right)
            {
                GetComponentInChildren<Raycast>().dright = 1f;
                GetComponent<Animator>().SetBool("Right", true);
            }
            
        }
    }
}
