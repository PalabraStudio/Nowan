using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelPlay : MonoBehaviour
{
    public AudioSource m_dringSound;
    public GameObject m_tel;
    // Start is called before the first frame update
    void Start()
    {
        m_dringSound.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_tel.GetComponent<TelCallEnnemy>().ring)
        {
            m_dringSound.UnPause();
        }
        else
        {
            m_dringSound.Pause();
        }
    }
}
