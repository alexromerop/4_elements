using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPush : MonoBehaviour
{
    private Rigidbody2D rgb2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.TryGetComponent<Rigidbody2D>(out rgb2);
        rgb2.AddForce(new Vector2(10f, 0));
    }
}
