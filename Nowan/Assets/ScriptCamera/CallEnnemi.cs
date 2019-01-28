using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnnemi : MonoBehaviour
{
    public GameObject nextNode;
    public GameObject[] ennemieList;
    // Start is called before the first frame update
    void Start()
    {
        ennemieList = GameObject.FindGameObjectsWithTag("Ennemie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
