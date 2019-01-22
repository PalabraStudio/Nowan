using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    public void OnMouseUp()
    {
        Application.LoadLevel("NiveauTest");
    }
}
