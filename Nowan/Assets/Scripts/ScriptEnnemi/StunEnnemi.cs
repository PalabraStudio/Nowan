using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEnnemi : MonoBehaviour
{
    public float stunRange;
    public bool inRange;
    public bool stun;
    private GameObject personnage;
    //private Stun perso;
    public float distance;
    private CalculateMove calcMov;
    // Start is called before the first frame update
    void Start()
    {
        personnage = GameObject.Find("Personnage");
        //perso = GameObject.Find("Personnage").GetComponent<Stun>();
        stun = false;
        calcMov = GetComponent<CalculateMove>();
        //stunRange = perso.stunRange;
    }

    // Update is called once per frame
    void Update()
    {
       /* inRange= InRange(personnage, stunRange);
        //if (perso.stun && !stun && InRange(personnage, stunRange))
        {
            stun = true;
        }
        /*if (!perso.stun && stun)
        {
            stun = false;
            GetComponent<MoveEnnemi>().waiter = 1;
            calcMov.CountDown = 0;
            calcMov.enabled = true;

        }
        if (stun)
        {
            GetComponent<MoveEnnemi>().waiter = 0;
            calcMov.enabled = false;
        }*/
    }
    bool InRange(GameObject personnage,float range)
    {
        if ((this.transform.position - personnage.transform.position).magnitude <= range)
        {
            return true;
        }
        return false;
    }
}
