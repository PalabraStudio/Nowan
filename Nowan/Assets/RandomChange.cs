using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChange : MonoBehaviour
{
    private int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomNum = Random.Range(0, 100);
        if (randomNum > 95)
        {
            this.GetComponent<Animator>().SetBool("Change", !this.GetComponent<Animator>().GetBool("Change"));
        }
    }
}
