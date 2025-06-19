using System;
using System.Collections;
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
        playerdata.UpdateLife(playerdata.MaxLife);
        playerdata.UpdateHP(playerdata.MaxHP);
        playerdata.isGround = false;
        playerdata.isMoveable = true;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
        PlayerData.OnDeathEvent += PlayerData_OnDeathEvent;
        KnockBackTrap.OnKnockBackEvent += KnockBackTrap_OnKnockBackEvent;
    }



    void Update()
    {
        if (gamedata.isGameEnd == false && playerdata.isMoveable == true)
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
    }

    private void UIManager_OnGameStartEvent()
    {
        playerdata.UpdateLife(playerdata.MaxLife);
        playerdata.UpdateHP(playerdata.MaxHP);
        playerdata.isGround = false;
        playerdata.isMoveable = true;
    }

    private void PlayerData_OnDeathEvent()
    {
        gamedata.isGameEnd = true;
    }

    private void KnockBackTrap_OnKnockBackEvent()
    {
        ApplyKnockback(gamedata.knockBackPower);  // �˹� ȿ�� ����
    }

    public void ApplyKnockback(float power)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        Vector3 knockbackDirection = new Vector3(-1, 1, 0).normalized;
        rigid.AddForce(knockbackDirection * power, ForceMode.Impulse);

        transform.rotation = Quaternion.Euler(0, 90, 0);

        rigid.useGravity = false;       // �˹� �߿��� �߷� ��Ȱ��ȭ
        //rigid.freezeRotation = true;  //�˹� �߿��� ȸ�� ��Ȱ��ȭ
        playerdata.isMoveable = false;  // �˹� �߿��� ���� ��Ȱ��ȭ

        StartCoroutine(ReturnAfterKnockback()); // ���� �ð��� ���� ��, �ٽ� Ȱ��ȭ
    }

    private IEnumerator ReturnAfterKnockback()
    {
        yield return new WaitForSeconds(0.5f);  // �˹� �� 0.5�� ��
        rigid.useGravity = true;                // �߷� �ٽ� Ȱ��ȭ
        //rigid.freezeRotation = false;         //ȸ�� �ٽ� Ȱ��ȭ
        playerdata.isMoveable = true;           // ���� �ٽ� Ȱ��ȭ
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