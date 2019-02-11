using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEnnemy : MonoBehaviour
{
    private float timer;
    public float stunTime;
    private bool stun;
    private GameObject node;
    private GameObject stunTarget;
    // Start is called before the first frame update
    void Start()
    {
        node = GetComponent<TelCallEnnemy>().nextNode;

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TelCallEnnemy>().miniEnnemi != null)
        {
            stunTarget = GetComponent<TelCallEnnemy>().miniEnnemi;
            stunTarget.GetComponent<CalculateMove>().destination = node;
        }
        if (stunTarget != null && stunTarget.GetComponent<CalculateMove>().origine == node && timer<=0 )
        {
            stun = true;
            timer = stunTime;
            this.GetComponent<TelCallEnnemy>().activation = false;
            this.GetComponent<TelCallEnnemy>().ring = false;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (stunTarget!=null&&stun&& timer <= 0)
        {
            stun = false;
            stunTarget.GetComponent<CalculateMove>().destination = stunTarget.GetComponent<CalculateMove>().routine[0];
            Debug.Log("ok");
            stunTarget = null;
            GetComponent<TelCallEnnemy>().miniEnnemi = null;

        }

    }

}
