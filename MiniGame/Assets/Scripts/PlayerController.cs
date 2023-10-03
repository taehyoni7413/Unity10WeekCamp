using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gameClear;
    public int itemCount;
    public float jumpPower;
    bool isJump;
    public GameManager manager;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isJump = false; // ������ �ȵ� ���¶�� ���� 
    }

    // Update is called once per frame


    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        { //isJump�� false�� ����(1ȸ�� ����)
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate() //���� ������ ���������̹Ƿ� FixedUpdate��� 
    {
        float h = Input.GetAxisRaw("Horizontal"); //GetAxisRaw : 0, 1 ,-1�� ������ 
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    public void GameOver()
    {

        gameClear.SetActive(true);


    }
    void OnCollisionEnter(Collision collision)
    { //���� �ٴڰ� ������ jump���� ���� 

        if (collision.gameObject.tag == "Floor") isJump = false;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 

        }
        if(other.tag == "Finish" && itemCount == manager.totalItemCount)
        { 
            GameOver();
            
            
        }

    }

}