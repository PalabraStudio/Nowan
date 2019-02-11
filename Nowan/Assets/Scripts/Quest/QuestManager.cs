using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject quest1Check;
    public GameObject quest2Check;
    // Start is called before the first frame update
    void Start()
    {
        quest1Check.SetActive(false);
        quest2Check.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
