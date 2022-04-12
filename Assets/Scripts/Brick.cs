using UnityEngine;

public class Brick : MonoBehaviour
{

    public LayerMask EnemyLayer;
    public float PushForce = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Jest ok");

            var hit = Physics2D.Raycast(transform.position, Vector2.up, 0.085f, EnemyLayer);
            if (hit.collider != null)
            {
                hit.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PushForce), ForceMode2D.Impulse);
                hit.transform.SendMessage("Dead");
            }
        }
    }
}
