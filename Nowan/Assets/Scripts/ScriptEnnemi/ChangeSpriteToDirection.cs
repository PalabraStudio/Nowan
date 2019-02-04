using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteToDirection : MonoBehaviour {


    public enum FaceDir { F_gauche,F_droite,F_haut,F_bas};
    private Vector2 direction;
    public Sprite gauche;
    public Sprite droite;
    public Sprite haut;
    public Sprite bas;
    private SpriteRenderer spriteRenderer;
    public FaceDir regard;


    void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	

	void Update () {
        direction = this.GetComponent<MoveEnnemi>().direction;
        if (direction.y == 1) { regard = FaceDir.F_haut; }
        else if (direction.y == -1) { regard = FaceDir.F_bas; }
        else if (direction.x == 1) { regard = FaceDir.F_droite; }
        else if (direction.x == -1) { regard = FaceDir.F_gauche; }
        if (regard == FaceDir.F_bas) { spriteRenderer.sprite = bas; }
        else if (regard == FaceDir.F_droite) { spriteRenderer.sprite = droite; }
        else if (regard == FaceDir.F_gauche) { spriteRenderer.sprite = gauche; }
        else if (regard == FaceDir.F_haut) { spriteRenderer.sprite = haut; }
    }
}



