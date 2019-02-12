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
        GetComponent<AudioSource>().mute = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player"&&detection&&GameObject.Find("Player").GetComponent<Invisibility>().is_invisible==false)
        {
            alarm = true;
            GetComponent<AudioSource>().mute = false;
        }
    }
}
