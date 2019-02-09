using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public float detection_distance;
    int dup, ddown, dleft, dright;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posEnemy = GetComponentInParent<Transform>().position;
        Debug.Log(GetComponentInParent<Transform>().position.x);
        Debug.Log(GetComponentInParent<Transform>().position.y);

        if (GetComponentInParent<MoveEnnemi>().up == true) { dup = 1; } else { dup = 0; }
        if (GetComponentInParent<MoveEnnemi>().down == true) { ddown = 1; } else { ddown = 0; }
        if (GetComponentInParent<MoveEnnemi>().left == true) { dleft = 1; } else { dleft = 0; }
        if (GetComponentInParent<MoveEnnemi>().right == true) { dright = 1; } else { dright = 0; }


        transform.localPosition = new Vector2(- dleft* 10 + dright * 10,- ddown * 10 + dup * 10);

        Vector2 ray_direction = new Vector2(-dleft * 11 + dright * 11, -ddown * 11 + dup * 11);
        Debug.Log(ray_direction.x);
        Debug.Log(ray_direction.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right , detection_distance);
        if(hit.transform.gameObject.name=="Personnage")
        {
            Debug.Log(hit.transform.gameObject.name);
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, ray_direction * detection_distance, Color.green);
        }
    }
}
