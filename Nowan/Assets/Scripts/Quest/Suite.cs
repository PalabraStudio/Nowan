using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        FindObjectOfType<DialogManager>().DisplayNextSentence();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<DialogManager>().DisplayNextSentence();
        }
    }
}
