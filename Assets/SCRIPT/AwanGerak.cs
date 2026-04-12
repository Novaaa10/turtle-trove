using UnityEngine;

public class AwanGerak : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            transform.position = new Vector2(-10f, transform.position.y);
        }
    }
}