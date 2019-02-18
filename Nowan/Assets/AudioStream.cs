using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStream : MonoBehaviour
{
    private bool repere;
    private GameObject[] ennemis;
    public AudioSource m_ambMusic;
    public AudioSource m_stressMusic;
    public GameObject nodetel;
    // Start is called before the first frame update
    void Start()
    {
        m_stressMusic.Pause();
        ennemis = GameObject.FindGameObjectsWithTag("Ennemi");
    }

    // Update is called once per frame
    void Update()
    {
        repere = false;
        foreach(GameObject ennemi in ennemis)
        {
            if (ennemi.GetComponent<CalculateMove>().lastKnownPNode!= null)
            {
                repere = true;
                m_stressMusic.UnPause();
                m_ambMusic.Pause();
            }
            if (repere)
            {
                m_stressMusic.UnPause();
                m_ambMusic.Pause();
            }
            else
            {
                m_stressMusic.Pause();
                m_ambMusic.UnPause();
            }
        }

    }
}
