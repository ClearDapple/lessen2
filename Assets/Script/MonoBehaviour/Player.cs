using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
   
    public Animator anime;
    private Rigidbody rigid;
    private BoxCollider box;
    [SerializeField] Transform m_PlayerContainer; //parent
    [SerializeField] Transform m_Player; //player

    private void Awake()
    {
        playerdata.Life = playerdata.MaxLife;
        playerdata.HP = playerdata.MaxHP;
        playerdata.isGround = false;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            m_PlayerContainer.Translate(Vector3.left * playerdata.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            m_PlayerContainer.Translate(Vector3.right * playerdata.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            m_PlayerContainer.Translate(Vector3.forward * playerdata.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            m_PlayerContainer.Translate(Vector3.back * playerdata.moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerdata.isGround)
        {
            rigid.AddForce(Vector3.up * playerdata.jumpForce, ForceMode.Impulse);
            playerdata.isGround = false;
        }
    }

    private void UIManager_OnGameStartEvent()
    {
        playerdata.Life = playerdata.MaxLife;
        playerdata.HP = playerdata.MaxHP;
        playerdata.isGround = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerdata.isGround = true;
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