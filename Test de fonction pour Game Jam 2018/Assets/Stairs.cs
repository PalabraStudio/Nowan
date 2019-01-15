using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position.Set(other.transform.position.x,
                                     other.transform.position.y,
                                    (other.transform.position.z +1 ) %2);
    }
}
