using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 1.0f;
    public float JumpForce = 1.0f;

    void Update()
    {
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
