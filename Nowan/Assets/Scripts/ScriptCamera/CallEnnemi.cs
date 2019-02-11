using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnnemi : MonoBehaviour
{
    public GameObject nextNode;
    public GameObject[] ennemiList;
    private float miniDist;
    private GameObject miniEnnemi;
    private bool first;
    // Start is called before the first frame update
    void Start()
    {
        ennemiList = GameObject.FindGameObjectsWithTag("Ennemi");
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PersoDetection>().alarm&&first)
        {
            first = false;
            miniDist = Distance(ennemiList[1]);
            miniEnnemi = ennemiList[1];
            foreach(GameObject ennemi in ennemiList)
            {
                if (Distance(ennemi) < miniDist)
                {
                    miniDist = Distance(ennemi);
                    miniEnnemi = ennemi;
                }
            }
            miniEnnemi.GetComponent<CalculateMove>().destination = nextNode;
        }
    }
    float Distance(GameObject ennemi)
    {
        return (this.transform.position - ennemi.transform.position).magnitude;
    }
}
