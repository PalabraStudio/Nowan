using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockCopy : MonoBehaviour {
    private List<GameObject> prochePerso;
    private bool copying;
    public GameObject Personnage;
    public List<GameObject> slots;
    private bool transforming;
    private Sprite tempSprite;
    private int temp;
    private bool unused;
    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        prochePerso = Personnage.GetComponent<Copy>().prochePerso;
        copying = Input.GetMouseButtonDown(0);
        transforming = Input.GetMouseButtonDown(1);
        if (copying)
        {
            unused = true;
            foreach (GameObject slot in slots)
            {
                if (prochePerso != new List<GameObject> () && slot.GetComponent<SpriteRenderer>().sprite==null&&unused)
                {
                    unused = false;
                    slot.GetComponent<SpriteRenderer>().sprite = PlusProcheSouris(prochePerso).GetComponent<SpriteRenderer>().sprite;
                    slot.GetComponent<TransformableID>().ID = PlusProcheSouris(prochePerso).GetComponent<TransformableObject>().ID;
                }
            }
        }
        
        if(transforming && slots[0].GetComponent<SpriteRenderer>().sprite != null)
        {
            Personnage.GetComponent<Animator>().SetInteger("State", slots[0].GetComponent<TransformableID>().ID);
            slots[0].GetComponent<SpriteRenderer>().sprite = slots[1].GetComponent<SpriteRenderer>().sprite;
            slots[0].GetComponent<TransformableID>().ID = slots[1].GetComponent<TransformableID>().ID;
            slots[1].GetComponent<SpriteRenderer>().sprite = slots[2].GetComponent<SpriteRenderer>().sprite;
            slots[1].GetComponent<TransformableID>().ID = slots[2].GetComponent<TransformableID>().ID;
            slots[2].GetComponent<SpriteRenderer>().sprite = null;
            slots[2].GetComponent<TransformableID>().ID = 0;
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel")>0)
        {
            Debug.Log("boite");
            if (slots[2].GetComponent<SpriteRenderer>().sprite != null)
            {
                tempSprite = slots[2].GetComponent<SpriteRenderer>().sprite;
                temp = slots[2].GetComponent<TransformableID>().ID;
                slots[2].GetComponent<SpriteRenderer>().sprite = slots[0].GetComponent<SpriteRenderer>().sprite;
                slots[2].GetComponent<TransformableID>().ID = slots[0].GetComponent<TransformableID>().ID;
                slots[0].GetComponent<SpriteRenderer>().sprite = slots[1].GetComponent<SpriteRenderer>().sprite;
                slots[0].GetComponent<TransformableID>().ID = slots[1].GetComponent<TransformableID>().ID;
                slots[1].GetComponent<SpriteRenderer>().sprite = tempSprite;
                slots[1].GetComponent<TransformableID>().ID = temp;

            }
            else if (slots[1].GetComponent<SpriteRenderer>().sprite != null)
            {
                tempSprite = slots[1].GetComponent<SpriteRenderer>().sprite;
                temp = slots[1].GetComponent<TransformableID>().ID;
                slots[1].GetComponent<SpriteRenderer>().sprite = slots[0].GetComponent<SpriteRenderer>().sprite;
                slots[1].GetComponent<TransformableID>().ID = slots[1].GetComponent<TransformableID>().ID;
                slots[0].GetComponent<SpriteRenderer>().sprite = tempSprite;
                slots[0].GetComponent<TransformableID>().ID = temp;

            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (slots[2].GetComponent<SpriteRenderer>().sprite != null)
            {
                tempSprite = slots[2].GetComponent<SpriteRenderer>().sprite;
                temp = slots[2].GetComponent<TransformableID>().ID;
                slots[2].GetComponent<SpriteRenderer>().sprite = slots[1].GetComponent<SpriteRenderer>().sprite;
                slots[2].GetComponent<TransformableID>().ID = slots[1].GetComponent<TransformableID>().ID;
                slots[1].GetComponent<SpriteRenderer>().sprite = slots[0].GetComponent<SpriteRenderer>().sprite;
                slots[1].GetComponent<TransformableID>().ID = slots[0].GetComponent<TransformableID>().ID;
                slots[0].GetComponent<SpriteRenderer>().sprite = tempSprite;
                slots[0].GetComponent<TransformableID>().ID = temp;

            }
            else if (slots[1].GetComponent<SpriteRenderer>().sprite != null)
            {
                tempSprite = slots[1].GetComponent<SpriteRenderer>().sprite;
                temp = slots[1].GetComponent<TransformableID>().ID;
                slots[1].GetComponent<SpriteRenderer>().sprite = slots[0].GetComponent<SpriteRenderer>().sprite;
                slots[1].GetComponent<TransformableID>().ID = slots[0].GetComponent<TransformableID>().ID;
                slots[0].GetComponent<SpriteRenderer>().sprite = tempSprite;
                slots[0].GetComponent<TransformableID>().ID = temp;
            }
        }
        

        /*
        foreach (GameObject slot in slot)
        {
            if (slot.GetComponent<UnityEngine.UI.Image>().sprite == null)
            {
                slot.SetActive(false);
            }
        }*/
    }

    GameObject PlusProcheSouris(List<GameObject> list)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 objPos;
            float minDist;
            GameObject nearest = list[0];
            minDist = (mousePos-PosOnScreen(nearest)).magnitude;
            foreach(GameObject obj in list)
                {
                    objPos = PosOnScreen(obj);

                    if (minDist > (objPos - mousePos).magnitude)
                    {
                        minDist = (objPos - mousePos).magnitude;
                        nearest = obj;
                    }
                }
            return nearest;
        }

    Vector2 PosOnScreen(GameObject obj)
        {
            return GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(obj.transform.position);
        }
}
