using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    UIManager uimanager;

    public Animator anime;
    private Rigidbody rigid;

    public float jumpForce = 5f;
    public float moveSpeed = 5;
    private bool isGround;

    private int HP;

    public int HPProperty
    {
        get { return HP; }
        set
        {
            if (value >= 0){HP = value;}
            if (HP > 100){HP = 100;}
            if (HP < 0){HP = 0;}
        }
    }


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        HP = 100;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }

        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput += 1;
        }

        float verticalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput -= 1;
        }
    }

    public void AddHP(int AddHP)
    {
        HP += AddHP;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            HP -= 10;
            uimanager.GetHP(HP);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}