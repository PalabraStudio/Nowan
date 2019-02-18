using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoDetection : MonoBehaviour
{
    public bool detection;
    public bool alarm;
    private float timer;
    public float time;
    void Start()
    {
        alarm = false;
        detection = true;
        GetComponent<AudioSource>().mute = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0&&alarm)
        {
            alarm = false;
            detection = false;
            GetComponent<AudioSource>().mute = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.gameObject.name == "Personnage"&&detection&&GameObject.Find("Personnage").GetComponent<Invisibility>().is_invisible==false)
        {
            alarm = true;
            GetComponent<AudioSource>().mute = false;
            timer = time;
        }
        if(collision.tag == "Ennemi" && timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
