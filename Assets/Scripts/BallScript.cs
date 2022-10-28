using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Vector2 startForce;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject partickleSplit;

    public GameObject nextBall;
    private void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

   
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 2f);
    }
    public void Split()
    {
        Instantiate(partickleSplit, transform.position, transform.rotation);

        if (nextBall != null)
        {        

            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<BallScript>().startForce = new Vector2(3f, 6f);
            ball2.GetComponent<BallScript>().startForce = new Vector2(-3f, 6f);
        }
        
        PlayerScript.splitCount++;

        Destroy(gameObject);
    }
}
