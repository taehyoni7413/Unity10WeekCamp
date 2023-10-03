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
        isJump = false; // 점프가 안된 상태라고 가정 
    }

    // Update is called once per frame


    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        { //isJump가 false일 때만(1회만 가능)
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate() //공의 움직임 물리현상이므로 FixedUpdate사용 
    {
        float h = Input.GetAxisRaw("Horizontal"); //GetAxisRaw : 0, 1 ,-1로 떨어짐 
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    public void GameOver()
    {

        gameClear.SetActive(true);


    }
    void OnCollisionEnter(Collision collision)
    { //공이 바닥과 닿으면 jump상태 해제 

        if (collision.gameObject.tag == "Floor") isJump = false;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
        { //충돌 오브젝트가 아이템일때
            itemCount++; // 점수 올리기 
            other.gameObject.SetActive(false); //아이템 비활성화 

        }
        if(other.tag == "Finish" && itemCount == manager.totalItemCount)
        { 
            GameOver();
            
            
        }

    }

}