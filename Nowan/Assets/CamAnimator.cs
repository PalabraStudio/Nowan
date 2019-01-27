using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimator : MonoBehaviour
{
    private Animator animator;
    public Sprite endOfBlink;
    private bool blinking;
    private bool alarm;
    public float rangeBlink;
    private float time;
    private bool blinkIsOver;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            time = rangeBlink+ ((Time.time*10)%rangeBlink);
            blinking = true;
        }
        else if (time != 0 && GetComponent<SpriteRenderer>().sprite == endOfBlink)
        {
            blinking = false;
        }
        else
        {
            time -= Time.deltaTime;
        }
            animator.SetBool("blinking", blinking);

    }
}
