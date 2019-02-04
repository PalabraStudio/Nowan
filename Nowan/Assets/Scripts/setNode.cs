using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setNode : MonoBehaviour {
    public GameObject noeud;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Node")
        {
            noeud = collider.gameObject;
        }
    }
}
