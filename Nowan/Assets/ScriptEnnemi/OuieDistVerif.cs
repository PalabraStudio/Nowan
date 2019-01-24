using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuieDistVerif : MonoBehaviour {
    public bool entendu;
    public float distance;
    private float zone;
    private Vector2 pPucePosition;
    private Vector2 ennemiPosition;
	// Use this for initialization
	void Start () {
        zone = this.GetComponent<CircleCollider2D>().radius;
	}
	
	// Update is called once per frame
	void Update () {
        pPucePosition = GameObject.Find("Personnage").transform.position;
        ennemiPosition = this.transform.position;
        distance = (pPucePosition - ennemiPosition).magnitude;
        if (distance <= zone)
        {
            entendu = true;
        }
        else
        {
            entendu = false;
        }
	}

}
