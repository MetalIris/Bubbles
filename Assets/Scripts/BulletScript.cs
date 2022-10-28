using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            col.GetComponent<BallScript>().Split();
        }
        Destroy(gameObject);
    }
}
