using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformable : MonoBehaviour {
    /*
    public GameObject highlight;
    private SpriteRenderer obj_sprite;
    private Color obj_color;

    public GameObject Perso;
    //Définit une case à cocher dans la liste des
    //COmponents de l'objet
    private bool transformable;private Vector2 c_perso;
    private Vector2 c_objet;
    private Vector2 v_distance;
    private float distance;
    //Je garde la distance limite dans ce code
    //Pour éviter de la changer pour un seul objet
    private float dist_limite = 50f; 
    private bool change = false;

    private void Start()
    {
        transformable = this.tag == "transformable";

        obj_sprite = this.GetComponent<SpriteRenderer>();
        obj_color = obj_sprite.color; 

        highlight = GameObject.Find("HighLightChoice");
        
    }

    //Verifie tout d'abord si l'objet est transformable
    private void Update()
    {
        if (transformable)
        {
            //Récupère les coordonnées du perso et de l'objet
            //Calcule leur distance
            c_perso = new Vector2(Perso.transform.position.x, Perso.transform.position.y);
            c_objet = new Vector2(this.transform.position.x, this.transform.position.y);
            v_distance = new Vector2(c_objet.x - c_perso.x, c_objet.y - c_perso.y);
            distance = Mathf.Sqrt(v_distance.x * v_distance.x + v_distance.y * v_distance.y);

            //Si la distance est en dessous de la limite
            //Et si l'objet est déjà transformé ou non
            if (distance<=dist_limite && !change)
            {
                obj_sprite.color = highlight.GetComponent<ColorChoice>().colorChoice;
                change = true;
            }
            else if (distance >= dist_limite && change)
            {
                obj_sprite.color = obj_color;
                change = false;
            }
        }
    }*/
    public void Start()
    {
        OnTriggerExit2D(null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
