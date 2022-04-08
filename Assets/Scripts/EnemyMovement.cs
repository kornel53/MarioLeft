using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public LayerMask GroundLayer;

    private float Speed = -0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Transform>().Translate(new Vector2(Speed * Time.deltaTime, 0));

        var hitL = Physics2D.Raycast(transform.position, Vector2.left, 0.085f, GroundLayer);
        var hitR = Physics2D.Raycast(transform.position, Vector2.right, 0.085f, GroundLayer);

        if (hitL.collider != null || hitR.collider != null) Speed = -Speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Speed = -Speed;
        }
    }
}
