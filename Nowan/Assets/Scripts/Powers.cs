using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public float phoneTimeReload;
    public int phoneUse;
    private float phoneTimer;
    private GameObject tel;
    private GameObject button;
    private GameObject gui;
    // Start is called before the first frame update
    void Start()
    {
        phoneTimer = 0;
        tel = GameObject.Find("Telephone");
        button = GameObject.Find("TelBoutton");
        gui = GameObject.Find("PowerCache");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && phoneTimer <= 0 && phoneUse != 0)
        {
            tel.GetComponent<TelCallEnnemy>().activation = true;
            phoneTimer = phoneTimeReload;
            phoneUse -= 1;
        }
        if (phoneTimer > 0)
        {
            phoneTimer -= Time.deltaTime;
            button.GetComponent<Animator>().SetBool("TelReady", false);
        }
        else if (phoneUse != 0)
        {
            button.GetComponent<Animator>().SetBool("TelReady", true);

        }
        if (phoneUse == 0)
        {
            gui.GetComponent<Animator>().SetBool("Tel", false);
        }

    }
}
