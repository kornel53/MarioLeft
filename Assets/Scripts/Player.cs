using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask GroundLayer;
    public float Speed = 1.0f;
    public float JumpForce = 1.0f;

    protected bool CanJump = false;

    void Update()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.085f, GroundLayer);
        CanJump = hit.collider != null ? true : false;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().Translate(new Vector2(-1 * Speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Translate(new Vector2(1 * Speed * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * JumpForce), ForceMode2D.Impulse);
        }
    }

}
