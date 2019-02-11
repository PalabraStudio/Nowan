using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPlay : MonoBehaviour
{
    public GameObject perso;
    public AudioSource m_walk;
    public AudioSource m_sprint;
    // Start is called before the first frame update
    void Start()
    {
        m_walk.Pause();
        m_sprint.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(perso.GetComponent<MoveCaracter>().vertical!=0 || perso.GetComponent<MoveCaracter>().horizontal != 0)
        {
            if (perso.GetComponent<MoveCaracter>().shift)
            {
                m_sprint.UnPause();
            }
            else
            {
                m_walk.UnPause();
            }
        }
        else
        {
            m_walk.Pause();
            m_sprint.Pause();
        }
    }
}
