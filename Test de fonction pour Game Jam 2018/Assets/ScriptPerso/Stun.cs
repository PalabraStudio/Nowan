using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public bool stun;
    public bool ready;
    public float timeWorking;
    public float timeReload;
    public float timer;
    public bool l;
    public float stunRange;
    // Start is called before the first frame update
    void Start()
    {
        stun = false;
        ready = true;
        timer = timeWorking;
    }

    // Update is called once per frame
    void Update()
    {
        l = Input.GetKeyDown("l");
        if (l && ready)
        {
            stun = true;
            ready = false;
        }
        if (!ready)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            stun = false;
        }
        if (timer < -timeReload)
        {
            ready = true;
            timer = timeWorking;
        }
    }
}
