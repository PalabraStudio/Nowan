using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return")&&(SceneManager.GetActiveScene()==SceneManager.GetSceneByName("GameOver")|| SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Victory")))
        {
            LoadMenu();
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnMouseUp()
    {
        LoadMenu();
    }
}
