using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool paused;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!paused)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Time.timeScale = 1;
            panel.SetActive(false);
        }
        paused = Time.timeScale == 1 ? false : true;
    }
}
