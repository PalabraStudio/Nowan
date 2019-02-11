using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmPlay : MonoBehaviour
{
    public GameObject m_Alarme;
    public AudioSource m_alarmStream;
    // Start is called before the first frame update
    void Start()
    {
        m_alarmStream.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Alarme.GetComponent<PersoDetection>().alarm)
        {
            m_alarmStream.UnPause();
        }
        else
        {
            m_alarmStream.Pause();
        }
    }
}
