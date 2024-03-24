using UnityEngine;
using System.Collections;

public class Pohyb : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public Rigidbody2D rb;
    private float lastJumpTime = 0.0f;
    private float jumpCooldown = 0.5f;
    private bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Freeze(float duration)
    {
        if (!isFrozen) 
        {
            StartCoroutine(FreezeCoroutine(duration));
        }
    }

    private IEnumerator FreezeCoroutine(float duration)
    {
        isFrozen = true;
        yield return new WaitForSeconds(duration);
        isFrozen = false;
    }

    void Update()
    {

         if (isFrozen)
        {
            return;
        }

        if (gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.smoothDeltaTime);
            }
            if (Input.GetKeyDown(KeyCode.W) && Time.time - lastJumpTime > jumpCooldown)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                lastJumpTime = Time.time;
            }
        }

        if (gameObject.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * speed * Time.smoothDeltaTime);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time - lastJumpTime > jumpCooldown)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                lastJumpTime = Time.time;
            }
        }
        
    }
}
