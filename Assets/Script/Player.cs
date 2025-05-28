using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public UIManager uimanager;

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

        //이거 수정
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 velocity = moveDirection * moveSpeed;
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
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