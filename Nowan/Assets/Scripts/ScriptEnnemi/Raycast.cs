using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public float detection_distance;
    float dup, ddown, dleft, dright;
    public bool repere { get { return vu; } }
    public bool vu;
    private float[] variationsCos;
    private float[] variationsSin;
    private int conteur;
    private float timer;
    public float to;

    // Start is called before the first frame update
    void Start()
    {
        variationsCos = new float[5] { 0.766f, 0.939f , 1f , 0.939f, 0.766f };
        variationsSin = new float[5] { 0.642f,0.342f , 0f,-0.342f , -0.642f };
        conteur = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 posEnemy = GetComponentInParent<Transform>().position;

        if (GetComponentInParent<MoveEnnemi>().up == true) { dup = 1f; } else { dup = 0f; }
        if (GetComponentInParent<MoveEnnemi>().down == true) { ddown = 1f; } else { ddown = 0f; }
        if (GetComponentInParent<MoveEnnemi>().left == true) { dleft = 1f; } else { dleft = 0f; }
        if (GetComponentInParent<MoveEnnemi>().right == true) { dright = 1f; } else { dright = 0f; }



        Vector2 ray_direction = new Vector2(-dleft + dright, -ddown + dup);
        if (ray_direction.x == 0)
        {
            ray_direction.y = ray_direction.y * variationsCos[conteur];
            ray_direction.x = variationsSin[conteur];
        }
        else
        {
            ray_direction.x = ray_direction.x * variationsCos[conteur];
            ray_direction.y =  variationsSin[conteur];
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, ray_direction, detection_distance);
        //Debug.Log(hit.transform.gameObject.name);
        if (hit&&(hit.transform.gameObject.name=="Personnage"|| hit.transform.gameObject.name == "Visu"))
        {

            Debug.Log(hit.transform.gameObject.name);
            timer = to;
            Debug.DrawLine(transform.position, new Vector2(ray_direction.x * detection_distance + transform.position.x, ray_direction.y * detection_distance + transform.position.y), Color.blue);
        }
        else
        {
            Debug.DrawLine(transform.position,new Vector2(ray_direction.x*detection_distance+transform.position.x, ray_direction.y*detection_distance + transform.position.y), Color.green);
        }
        conteur++;
        if (conteur == 5)
        {
            conteur = 0;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            vu = true;
        }
        else
        {
            vu = false;
        }
    }
}
