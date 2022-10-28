using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    [SerializeField] private Rigidbody2D playerRigidBody;

    private float movement = 0f;

    [Header("Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;


    [Header("Bullet")]
    public BulletScript bullet;
    public Transform fireSpot;
    private bool Fire;

   
    [Header("WinCondition")]
    [SerializeField] private int splitToWin;
    public static int splitCount;
    
    

    private void Start()
    {
        splitCount = 0;
        Fire = true;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
    private void Update()
    {
        movement = Input.GetAxis("Horizontal") * playerSpeed;

        if (Input.GetButtonDown("Fire1") && Fire == true)
        {
            StartCoroutine(Shoot());
        }

        if(splitCount == splitToWin)
        {
            winPanel.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + new Vector2(movement * Time.deltaTime, 0f));
    }

    IEnumerator Shoot()
    {
        Fire = false;
        Instantiate(bullet, fireSpot.position, fireSpot.rotation);
        yield return new WaitForSeconds(0.5f);
        Fire = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            splitCount = 0;
            Destroy(gameObject);
            Fire = false;
            gameOverPanel.SetActive(true);
        }
    }
}
