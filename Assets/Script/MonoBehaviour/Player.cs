using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
   
    //public Animator anime;
    private Rigidbody rigid;

    [SerializeField] Transform m_PlayerContainer; //parent
    [SerializeField] Transform m_Player; //player

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerdata.HP = 100;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_PlayerContainer.Translate(Vector3.left * playerdata.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_PlayerContainer.Translate(Vector3.right * playerdata.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_PlayerContainer.Translate(Vector3.forward * playerdata.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_PlayerContainer.Translate(Vector3.back * playerdata.moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerdata.isGround)
        {
            rigid.AddForce(Vector3.up * playerdata.jumpForce, ForceMode.Impulse);
            playerdata.isGround = false;
        }

        if (playerdata.HP > playerdata.MaxHP) { playerdata.HP = playerdata.MaxHP; }
        if (playerdata.HP < playerdata.MinHP) { playerdata.HP = playerdata.MinHP; }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerdata.isGround = true;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            playerdata.HP -= gamedata.Demege;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerdata.isGround = false;
        }
    }
}