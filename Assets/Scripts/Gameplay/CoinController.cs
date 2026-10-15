using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float rotator;
    void Awake()
    {
        rotator = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotator, transform.rotation.z);
        rotator += Time.deltaTime * 50;
        if (rotator > 359) rotator = 0;
    }
}
