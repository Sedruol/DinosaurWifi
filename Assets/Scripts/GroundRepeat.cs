using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
            transform.Translate(Vector2.right * 2f * width);
    }
}