using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

   
    private Vector2 Direction;
    private Rigidbody2D rigidbody2d;


    // Start is called before the first frame update

    private void Update()
    {
        Destroy(gameObject, 1);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //this.transform.loca = Direction;
    }
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
