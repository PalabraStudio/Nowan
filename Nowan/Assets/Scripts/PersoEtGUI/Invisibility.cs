using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public int time_invisibility;
    private int time;
    public bool is_invisible = false;
    private Color classic;
    private Color invisible = new Color(1f, 1f, 1f, .3f);
    public bool is_used = false;


    // Start is called before the first frame update
    void Start()
    {
        classic = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("2") && is_used == false)
        {
            
            GameObject.Find("Invisible").GetComponent<Animator>().SetBool("Ready", false);
            GameObject.Find("PowerCache").GetComponent<Animator>().SetBool("Inv", false);
            time = time_invisibility;
            is_invisible = true;
            is_used = true;
            
        }
        if(time >= 100)
        {
            GetComponent<SpriteRenderer>().color = invisible;
            time--;
        }
        else if (time < 200 && time >= 0)
        {
            if (time % 25 > 12) //clignotement à la fin du bonus invisiblité
            {
                GetComponent<SpriteRenderer>().color = invisible;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = classic;
            }
            time--;
            
        }
        else
        {
            GetComponent<SpriteRenderer>().color = classic;
            is_invisible = false;
        }
    }
}
