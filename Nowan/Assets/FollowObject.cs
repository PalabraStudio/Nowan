using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    public GameObject Personnage;

    //Change la posisition par rapport à l'objet à suivre
    //J'i mis arbitrairement Personnage comme nom (meme si
    //c'est pas bien les majuscules au début etc)
	void Update () {
        this.transform.position = new Vector3(Personnage.transform.position.x,
                                                Personnage.transform.position.y,
                                                this.transform.position.z);
	}
}
