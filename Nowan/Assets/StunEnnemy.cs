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
        }
        if (stunTarget.GetComponent<CalculateMove>().origine == node)
        {

        }


    }

}
