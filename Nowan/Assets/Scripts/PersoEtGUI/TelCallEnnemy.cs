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
    private GameObject perso;
    public GameObject power;
    public GameObject boutton;
    // Start is called before the first frame update
    void Start()
    {
        ennemiList = GameObject.FindGameObjectsWithTag("Ennemi");
        first = true;
        ring = false;
        activation = false;
        perso = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && (perso.transform.position - this.transform.position).magnitude <= 200&&boutton.GetComponent<Animator>().GetBool("TelReady"))
        {
            boutton.GetComponent<Animator>().SetBool("TelReady", false);
            power.GetComponent<Animator>().SetBool("Tel", false);

               activation = true;
        }
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
