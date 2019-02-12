using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cinematique : MonoBehaviour
{
    public VideoPlayer cinematique;
    private float startTime;

    const float videoLength = 25;

    private void Awake()
    {
        StartCoroutine(Loop());
        startTime = Time.time;
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (Time.time - startTime >= videoLength)
                SceneManager.LoadScene("Level1");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) SceneManager.LoadScene("Level1");
    }
}
