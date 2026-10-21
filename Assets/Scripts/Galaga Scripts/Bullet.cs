using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
