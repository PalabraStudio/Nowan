using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockCopy : MonoBehaviour {
    private Sprite image;
    private bool copying;
    public GameObject Personnage;
    public List<GameObject> slots;
    private bool transforming;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        image = Personnage.GetComponent<Copy>().image;
        copying = Input.GetKeyDown("e");
        transforming = Input.GetKeyDown("z");
        foreach (GameObject slot in slots)
        {
            if (copying && image != null && slot.GetComponent<SpriteRenderer>().sprite==null)
            {
                slot.SetActive(true);
                slot.GetComponent<SpriteRenderer>().sprite = image;
                image = null;
            }
        }
        if(transforming && slots[0].GetComponent<SpriteRenderer>().sprite != null)
        {
            slots[0].GetComponent<SpriteRenderer>().sprite = slots[1].GetComponent<SpriteRenderer>().sprite;
            slots[1].GetComponent<SpriteRenderer>().sprite = slots[2].GetComponent<SpriteRenderer>().sprite;
            slots[2].GetComponent<SpriteRenderer>().sprite = null;
        }/*
        foreach (GameObject slot in slot)
        {
            if (slot.GetComponent<UnityEngine.UI.Image>().sprite == null)
            {
                slot.SetActive(false);
            }
        }*/
    }
}
