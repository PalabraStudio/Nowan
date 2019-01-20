using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BoutonStun : MonoBehaviour
{
    public bool stun;
    public bool ready;
    public Color normal;
    public Color working;
    public Color reload;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stun = GameObject.Find("Personnage").GetComponent<Stun>().stun;
        ready = GameObject.Find("Personnage").GetComponent<Stun>().ready;
        if (stun)
        {
            GetComponent<Image>().color = working;
        }
        else if (!ready)
        {
            GetComponent<Image>().color = reload;
        }
        else { GetComponent<Image>().color = normal; }
    }
}
