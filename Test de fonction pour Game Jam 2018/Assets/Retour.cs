using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript;
using Unity;
using Image = UnityEngine.UI.Image;

public class Retour : MonoBehaviour
{
    public bool invisibleTest;
    public bool ready;
    public Color normal;
    public Color invisible;
    public Color charge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        invisibleTest = GameObject.Find("Personnage").GetComponent<Invisibilite>().invisble;
        ready = GameObject.Find("Personnage").GetComponent<Invisibilite>().ready;
        if (invisibleTest)
        {
            GetComponent<Image>().color = invisible;
        }
        else if (!ready)
        {
            GetComponent<Image>().color = charge;
        }
        else { GetComponent<Image>().color = normal; }
    }
}
