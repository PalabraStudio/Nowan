using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPoint : MonoBehaviour
{
    public GameObject node;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = node.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
