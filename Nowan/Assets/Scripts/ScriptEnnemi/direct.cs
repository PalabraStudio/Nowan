using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direct : MonoBehaviour {
    public List<Vector2> lPath;
    public List<GameObject> path;
    public List<GameObject> lNoeud;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lPath = this.GetComponentInParent<CalculateMove>().vPath;
        lNoeud = this.GetComponentInParent<CalculateMove>().lNoeud;
        path = this.GetComponentInParent<CalculateMove>().path;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Node")
        {



            this.GetComponentInParent<CalculateMove>().origine = collision.gameObject;

            if (path.Count != 0)
            {
                if (path[path.Count - 1].name == collision.name|| this.GetComponentInParent<CalculateMove>().routining)
                {
                    this.GetComponentInParent<MoveEnnemi>().ismoving = true;
                }
                if (this.GetComponentInParent<MoveEnnemi>().ismoving)
                {
                    this.GetComponentInParent<MoveEnnemi>().direction = lPath[lNoeud.IndexOf(collision.gameObject)];
                    this.GetComponentInParent<CalculateMove>().current = collision.gameObject;

                }
                if (path[0].name == collision.name && !this.GetComponentInParent<CalculateMove>().routining)
                {
                    this.GetComponentInParent<MoveEnnemi>().ismoving = false;
                }
            }
            


        }
    }
}
