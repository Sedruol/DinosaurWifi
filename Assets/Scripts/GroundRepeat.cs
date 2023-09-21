using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private float width;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
    }
    void Update()
    {
        if (transform.position.x < -width)
            transform.Translate(Vector2.right * 2f * width);
    }
}