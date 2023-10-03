using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager manager;
    public int life;
    //public GameObject bulletprfab;
    private Rigidbody playerRigidbody;// 이동에 사용할 리지드바디 컨트롤러
    public float speed = 8f; //이동 속력
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); //게임오브젝트에서 Rigidbody 컴포넌트를 찾아 바로 할당
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed,0f, zSpeed);

        playerRigidbody.velocity = newVelocity;
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
            {
            life--;
            manager.UpdateLifeIcon(life);
        }
        if(life == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
