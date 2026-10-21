using UnityEngine;

public class EnemyFast : MonoBehaviour
{
    public float speed = 3;
    public GameObject explosion;

    public float zip = 0;
    public float zipTimer = 0, zipWait = 3;

    float movedRight = 0; //Moves between 1 and 0

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);

        zipTimer += Time.deltaTime;
        if (zipTimer > zipWait)
        {
            if (movedRight == 0)
            {
                zipTimer = 0;
                transform.Translate(transform.right * zip);
                movedRight = 1;
            }
            else
            {
                zipTimer = 0;
                transform.Translate(-transform.right * zip);
                movedRight = 0;
            }
        }

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                Destroy(collision.gameObject);

            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);
        }
    }
}
