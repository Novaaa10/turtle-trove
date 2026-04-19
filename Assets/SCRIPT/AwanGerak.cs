using UnityEngine;

public class AwanGerak : MonoBehaviour
{
    public float speed = 1f;
    public float lebarAwan = 20f; // isi sesuai lebar sprite

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > lebarAwan)
        {
            transform.position = new Vector3(
                transform.position.x - (lebarAwan * 2),
                transform.position.y,
                transform.position.z
            );
        }
    }
}