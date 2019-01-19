using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilite : MonoBehaviour
{
    public float invisibleTimer;
    public float timeCounter;
    public bool invisble;
    public bool ready;
    public float reloadTime;
    public bool i;
    // Start is called before the first frame update
    void Start()
    {
        timeCounter = invisibleTimer;
        invisble = false;
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        i=Input.GetKeyDown("i");
        if (i && ready)
        {
            invisble = true;
            ready = false;
        }
        if (!ready)
        {
            timeCounter -= Time.deltaTime;
        }
        if (timeCounter < 0)
        {
            invisble = false;
        }
        if (timeCounter < -reloadTime)
        {
            ready = true;
            timeCounter = invisibleTimer;
        }

    }
}
