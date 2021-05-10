﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movment : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    Rigidbody2D Rigidbody2D;

    public bool in_ground;
    public float horizontal;

    public int Health =1;

    public float element_time;
    public GameObject Flame;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //flip body
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //chek ground
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            in_ground = true;
        }
        else in_ground = false;

        if (Input.GetKeyDown("space") && in_ground)
        {
            Jump();
        }
        if (Input.GetKeyDown("e") )
        {
            flame();
        }
        if (Health <= 0)
        {
            Dead();
            //SceneManager.LoadScene(sceneIndex);
        }

    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal * Speed, Rigidbody2D.velocity.y);
    }





    private void Jump()
    {
        Rigidbody2D.AddForce(transform.up * JumpForce);
    }
    private void Dead()
    {
        //StartCoroutine(DeadAnimation());
        //audioManager.PlayDeath();
        //SceneManager.LoadScene(sceneIndex);
    }
    public void Hit()
    {
        Rigidbody2D.AddForce(transform.up * Vector2.up);
        Health -= 1;
        
        if (Health == 0) Debug.Log("Dead");
       
    }
    public void flame()
    {
        float dir;
        float dir_;

        Vector3 direction;

        if (this.transform.localScale.x == 1.0f) { direction = Vector3.right; dir = 0; dir_ = -90; }
        else { direction = Vector3.left; dir = 180; dir_=90; }
       
        GameObject inst_Flame = Instantiate(Flame, transform.position, transform.rotation * Quaternion.Euler(dir_, 0f, dir));
        
        inst_Flame.GetComponent<Fire>().SetDirection(direction);
    }
}