using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 1.0f;
    public float JumpForce = 1.0f;

    protected bool CanJump = true;

    void Update()
    {
        var hit = Physics2D.Raycast(GetComponent<Transform>().position, Vector2.down, 0.08f);
        CanJump = hit.collider != null ? true : false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().Translate(new Vector2(-1 * Speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Translate(new Vector2(1 * Speed * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * JumpForce), ForceMode2D.Impulse);
        }
    }
}
