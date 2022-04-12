using UnityEngine;

public class MysteryBox : MonoBehaviour
{

    public enum Type
    {
        Coin, Upgrade
    }

    public Type BoxType;

    public LayerMask EnemyLayer;
    public GameObject DropCoinPrefab;
    public GameObject UpgradePrefab;
    public float PushForce = 2f;

    protected bool IsEnabled = true;

    public Sprite DisabledMysteryBoxSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && IsEnabled)
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.up, 0.085f, EnemyLayer);
            if (hit.collider != null)
            {
                hit.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PushForce), ForceMode2D.Impulse);
                hit.transform.SendMessage("Dead");
            }

            switch(BoxType)
            {
                case Type.Coin:
                    Coin();
                    break;
                case Type.Upgrade:
                    Upgrade();
                    break;
            }

        }
    }

    private void Coin()
    {
        Instantiate(DropCoinPrefab, new Vector2(transform.position.x, transform.position.y + 0.16f), transform.rotation);
        DisableMysteryBox();
    }

    private void Upgrade()
    {
        Instantiate(UpgradePrefab, new Vector2(transform.position.x, transform.position.y + 0.16f), transform.rotation);
        DisableMysteryBox();

    }
    private void DisableMysteryBox()
    {
        IsEnabled = false;
        GetComponent<SpriteRenderer>().sprite = DisabledMysteryBoxSprite;
    }
}
