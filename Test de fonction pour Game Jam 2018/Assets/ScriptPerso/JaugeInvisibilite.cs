using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class JaugeInvisibilite : MonoBehaviour
{
    public float timer;
    private float timeWorking;
    private float timeReload;
    // Start is called before the first frame update
    void Start()
    {
        timeWorking = GameObject.Find("Personnage").GetComponent<Invisibilite>().invisibleTimer;
        timeReload = GameObject.Find("Personnage").GetComponent<Invisibilite>().reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer = GameObject.Find("Personnage").GetComponent<Invisibilite>().timeCounter;
        GetComponent<Image>().fillAmount = timer > 0 ? timer / timeWorking : -timer / timeReload;
    }
}

