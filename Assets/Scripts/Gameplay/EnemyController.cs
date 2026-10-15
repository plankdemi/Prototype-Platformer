using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float patrolRange;
    private float targetPosX;
    private bool goRight;
    private float speed;

    void Awake()
    {
        patrolRange = 8f;
        targetPosX = transform.position.x + patrolRange;
        Debug.Log(targetPosX);
        goRight = true;
        speed = 3f;
    }

    void Update()
    {
        if ((transform.position.x < targetPosX) && goRight)
        {
            transform.position += (Vector3)Vector2.right * Time.deltaTime * speed;

        }
        else if (goRight)
        {
            Debug.Log("called here");
            goRight = false;
            targetPosX -= patrolRange;

        }
        else if ((transform.position.x > targetPosX) && !goRight)
        {
            transform.position -= (Vector3)Vector2.right * Time.deltaTime * speed;
        }
        else
        {
            Debug.Log("and called here");
            goRight = true;
            targetPosX += patrolRange;
        }
    }
}
