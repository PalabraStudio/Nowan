using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnMouseUp()
    {
        Application.Quit();

        //Application.Quit ne fonctionne que sur une version Build (un .exe) du jeu. Pour tester dans Unity Editor, il faut :
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
