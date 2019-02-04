using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private float timeCount;
    public float timeForHit;
    private GameObject player;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = timeForHit;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        if (timeCount < 0 && Distance(player))
        {
            player.GetComponent<Life>().life -= 1;
            timeCount = timeForHit;
        }
        else if (timeCount < 0)
        {
            timeCount = timeForHit;
        }
    }
    bool Distance(GameObject perso)
    {
        if ((transform.position - perso.transform.position).magnitude <= distance)
        {
            return true;
        }
        return false;
    }
}
