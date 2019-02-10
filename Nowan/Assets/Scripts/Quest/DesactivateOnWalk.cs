using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateOnWalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Personnage")
        {
            this.GetComponent<DialogTrigger>().TriggerDialog();
            this.gameObject.SetActive(false);
        }
       
    }
}
