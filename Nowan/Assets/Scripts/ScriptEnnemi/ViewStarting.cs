using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewStarting : MonoBehaviour
{
    public enum cote { up,down,left,right}
    public cote choix;
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
        
    }
}
