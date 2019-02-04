using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public GameObject slot1;
    private Sprite slot1Sprite;
    public List<GameObject> prochePerso;
    public float secondsToWait = 10;
	public float secondsLeft = 10;

    /* private SpriteRenderer rend;
    private string transformable; 
    private bool z; */

    public List<GameObject> p_prochePerso { get { return prochePerso; } }
    /* L'image depend du GameObject tra1nformable dont on touche le trigger
     * donc cette variable ne doit pas pouvoir être Set en dehors.
     * Par contre, on veut y avoir acces dans StockCopy, donc il faut un getter public. */


    void Start()
    {
    }

    //Active quand on est dans une zone dite de "trigger" et
    //Recupère dans collision l'objet avec lequel on est en contact
    //Si l'objet est transformable alors on recupère son sprite
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* transformable = collision.tag
         * il me semble que la variable est peu utile, on pourrait s'en passer */
        if (collision.tag == "Transformable")
        {
            //m_image = collision.GetComponent<SpriteRenderer>().sprite;
            prochePerso.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //m_image = null;
        prochePerso.Remove(collision.gameObject);
    }

    //Si on a qqch dans image et que on appuie sur e 
    //alors on change de sprite
    void Update()
    {
        slot1Sprite = slot1.GetComponent<SpriteRenderer>().sprite;
        /* bool z = Input.GetKeyDown("z");
         * comme pour transformable, ce me semble peu utile, autant eviter les allocations memoire quand on peut */
        /*if (Input.GetKeyDown("e") && m_image != null && slot1Sprite == null)
        /* image != null permet d'eviter de colorer le slot en blanc si on appuie sur z en dehors d'un trigger 
        {
            /* rend.sprite = slot1.GetComponent<UnityEngine.UI.Image>().sprite;
             * je crois que tu cherchais plutot a faire :  
            slot1Sprite = m_image;

        }*/
        if (Input.GetMouseButtonDown(1) && slot1Sprite != null)
        {
            secondsLeft = secondsToWait;
        }
    }
    
    void FixedUpdate () {
        if (this.GetComponent<Animator>().GetInteger("State") != 0){
            secondsLeft -= Time.fixedDeltaTime;
            if (secondsLeft <= 0){
                this.GetComponent<Animator>().SetInteger("State", 0);
                secondsLeft = secondsToWait;
            }
        }
	}

    void updateMoveCharacter(MoveCaracter move, string spriteName)
    {
        this.GetComponent<CircleCollider2D>().isTrigger = spriteName.Contains("bat");
        if (spriteName.Contains("bat"))
            move.speed = 2;
        else if (spriteName.Contains("mouse"))
            move.speed = 1;
        else move.speed = 1.5f;
    }
}