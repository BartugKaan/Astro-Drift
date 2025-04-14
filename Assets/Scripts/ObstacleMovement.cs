using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float yFinalPoint = -3.5f;
    [SerializeField] float yStartPoint = -13f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] bool goingUp = true;

    [SerializeField] float epsilon = 0.01f;

    void Update()
    {
        float direction = goingUp ? 1f : -1f;
        transform.Translate(Vector3.up * direction * movementSpeed * Time.deltaTime);

        if (goingUp && transform.position.y >= yFinalPoint - epsilon)
        {
            goingUp = false;
        }
        else if (!goingUp && transform.position.y <= yStartPoint + epsilon)
        {
            goingUp = true;
        }
    }
}
