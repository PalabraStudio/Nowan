using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSound : MonoBehaviour
{
    public GameObject m_ennemi;
    public AudioSource m_vu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ennemi.GetComponent<Raycast>().vu)
        {
            m_vu.Play();
        }
    }
}
