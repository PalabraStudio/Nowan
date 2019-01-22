using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public Text m_text;
    private void OnMouseEnter()
    {
        m_text.color = new Color(0.9f, 0.9f, 0.9f);
    }
    
    private void OnMouseExit()
    {
        m_text.color = new Color(0.2f, 0.2f, 0.2f);
    }
}
