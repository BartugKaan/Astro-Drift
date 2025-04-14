using UnityEngine;

public class FighterMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float lifeSpan = 20f;
    [SerializeField] ParticleSystem rocketParticleOne;
    [SerializeField] ParticleSystem rocketParticleTwo;


    void Update()
    {
        if (Time.time <= lifeSpan)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * movementSpeed);
        }
        else
        {
            rocketParticleOne.Stop();
            rocketParticleTwo.Stop();
            Destroy(gameObject);
        }
    }

}
