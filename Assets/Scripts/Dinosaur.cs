using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] private float forceUp;
    [SerializeField] private GameObject ground;
    private bool isGrounded = true;
    private Rigidbody2D rbDino;
    private Animator animDino;
    void Start()
    {
        rbDino = GetComponent<Rigidbody2D>();
        animDino = GetComponent<Animator>();
    }
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            animDino.SetTrigger("Die");
            Time.timeScale = 0f;
        }
    }
}