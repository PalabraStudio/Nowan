using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int life;
    public int lifemax;
    private int lifetamp;
    public float timeOfBlank;
    private float timer;
    public Color classic;
    public Color hit;
    // Start is called before the first frame update
    void Start()
    {
        classic = GetComponent<SpriteRenderer>().color;
        life = lifemax;
        lifetamp = life;
    }

    // Update is called once per frame
    void Update()
    {

        if (life == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (life != lifetamp)
        {

            lifetamp = life;
            timer = timeOfBlank;
        }
        if (timer > 0)
        {
            GetComponent<SpriteRenderer>().color = hit;
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            GetComponent<SpriteRenderer>().color = classic;
        }
    }
}
