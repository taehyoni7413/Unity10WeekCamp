using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager manager;
    public int life;
    //public GameObject bulletprfab;
    private Rigidbody playerRigidbody;// �̵��� ����� ������ٵ� ��Ʈ�ѷ�
    public float speed = 8f; //�̵� �ӷ�
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); //���ӿ�����Ʈ���� Rigidbody ������Ʈ�� ã�� �ٷ� �Ҵ�
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
