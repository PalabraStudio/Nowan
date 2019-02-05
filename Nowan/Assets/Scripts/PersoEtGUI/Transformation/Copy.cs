﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public GameObject slot1;
    private Sprite slot1Sprite;
    public List<GameObject> prochePerso;
    public float secondsToWait = 10;
	public float secondsLeft = 10;


    void Start()
    {
    }

    //Active quand on est dans une zone dite de "trigger" et
    //Recupère dans collision l'objet avec lequel on est en contact
    //Si l'objet est transformable alors on le recupère
    void FixedUpdate () {
        if (this.GetComponent<Animator>().GetInteger("State") != 0){
            secondsLeft -= Time.fixedDeltaTime;
            if (secondsLeft <= 0){
                this.GetComponent<Animator>().SetInteger("State", 0);
                secondsLeft = secondsToWait;
            }
        }
        slot1Sprite = slot1.GetComponent<SpriteRenderer>().sprite;
        if (Input.GetMouseButtonDown(1) && slot1Sprite != null)
        {
            secondsLeft = secondsToWait;
        }
	}
}