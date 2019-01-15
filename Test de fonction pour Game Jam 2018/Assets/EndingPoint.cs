using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPoint : MonoBehaviour
{
    public UnityEngine.UI.Text EndingMessage;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndingMessage.color = new Color(225, 225, 225);
    }
}
