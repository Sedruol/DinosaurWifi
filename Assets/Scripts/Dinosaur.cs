using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] private float forceUp;
    [SerializeField] private GameObject ground;
    private bool isGrounded = true;
    private Rigidbody2D rbDino;
    private Animator animDino;
    // Start is called before the first frame update
    void Start()
    {
        rbDino = GetComponent<Rigidbody2D>();
        animDino = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            isGrounded = false;
            animDino.SetBool("IsGrounded", isGrounded);
            rbDino.AddForce(Vector2.up * forceUp);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == ground.layer)
        {
            isGrounded = true;
            animDino.SetBool("IsGrounded", isGrounded);
        }
    }
}