using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseHole : MonoBehaviour
{
    public GameObject personnage;
    public Collider2D collision;
    private TilemapRenderer m_renderer;

    private void Start()
    {
        m_renderer = gameObject.GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (personnage.GetComponent<SpriteRenderer>().sprite.name.StartsWith("mouse"))
        {
            collision.enabled = false;
            gameObject.GetComponent<TilemapRenderer>().sortingLayerName = "Tunnel";
        }
        else
        {
            collision.enabled = true;
            gameObject.GetComponent<TilemapRenderer>().sortingLayerName = "Wall";
        }
    }
}
