using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public Sprite DeadSprite;
    public float PushForce = 2f;

    public bool IsAlive = true;

    void Update()
    {
        if (!IsAlive) return;

        var hitL = Physics2D.Raycast(transform.position, Vector2.left, 0.085f, PlayerLayer);
        var hitR = Physics2D.Raycast(transform.position, Vector2.right, 0.085f, PlayerLayer);
        var hitD = Physics2D.Raycast(transform.position, Vector2.down, 0.085f, PlayerLayer);

        if (hitL.collider != null || hitR.collider != null || hitD.collider != null) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PushForce), ForceMode2D.Impulse);

            Dead();
        }
    }

    public void Dead()
    {
        IsAlive = false;
        GetComponent<LeftRightMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = DeadSprite;

        Destroy(gameObject, 2f);
    }
}
