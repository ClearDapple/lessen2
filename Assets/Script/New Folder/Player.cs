using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //public UIManager uimanager;
    //public GameManager gamemanager;
    //public TileManager tilemanager;
    //public TrapManager trapmanager;

    //public Animator anime;
    //private Rigidbody rigid;



    //public int HPProperty
    //{
    //    get { return HP; }
    //    set
    //    {
    //        if (HP > MaxHP) { HP = MaxHP; }
    //        if (HP < MinHP) { HP = MinHP; }
    //    }
    //}




    //void Start()
    //{
    //    rigid = GetComponent<Rigidbody>();
    //    HP = 100;
    //    Respawn();
    //}

    //void Update()
    //{

    //    //이거 수정:안움직임
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");
    //    Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    //    Vector3 velocity = moveDirection * moveSpeed;

    //    if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
    //    {
    //        rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        isGround = false;
    //    }

    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        Respawn();
    //    }
    //}

    //public void AddHP(int AddHP)
    //{
    //    HP += AddHP;
    //}

    //public void Respawn()
    //{
    //    gameObject.transform.position = new Vector3(1.5f, 5f, tilemanager.verticalCount * tilemanager.tileSpacing / 2f);
    //}

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = true;
    //    }

    //    if (collision.gameObject.CompareTag("Trap"))
    //    {
    //        HP -= 10;
    //        uimanager.GetHP(HP);
    //    }
    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = false;
    //    }
    //}
}