using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] float speed = 7;
    [SerializeField] float height = 2f;
    [SerializeField] float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float newY = startY + Mathf.PingPong(Time.time * speed, height);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
