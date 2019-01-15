using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatedPlatform : MonoBehaviour {
    public GameObject personnage;
    public Collider2D collision;

    // Update is called once per frame
    void Update () {
        collision.enabled = personnage.transform.position.z == 1;
    }
}
