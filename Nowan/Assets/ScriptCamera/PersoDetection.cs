using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoDetection : MonoBehaviour
{
    public bool detection;
    public bool alarm;
    void Start()
    {
        alarm = false;
        detection = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&detection)
        {
            alarm = true;
        }
    }
}
