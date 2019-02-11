using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelCallEnnemy : MonoBehaviour
{
    public GameObject nextNode;
    public GameObject[] ennemiList;
    private float miniDist;
    public GameObject miniEnnemi;
    private bool first;
    public bool ring;
    public bool activation;
    // Start is called before the first frame update
    void Start()
    {
        ennemiList = GameObject.FindGameObjectsWithTag("Ennemie");
        first = true;
        ring = false;
        activation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activation && first)
        {
            first = false;
            ring = true;

                    miniDist = Distance(ennemiList[1]);
            miniEnnemi = ennemiList[1];
            foreach (GameObject ennemi in ennemiList)
            {
                if (Distance(ennemi) < miniDist)
                {
                    miniDist = Distance(ennemi);
                    miniEnnemi = ennemi;
                }
            }
            miniEnnemi.GetComponent<CalculateMove>().destination = nextNode;
        }
        GetComponent<Animator>().SetBool("Sonne", ring);

    }
    float Distance(GameObject ennemi)
    {
        return (this.transform.position - ennemi.transform.position).magnitude;
    }
}
