using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour
{
    public float PushForce = 2f;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PushForce), ForceMode2D.Impulse);
        Destroy(gameObject, 1f);
    }

}
