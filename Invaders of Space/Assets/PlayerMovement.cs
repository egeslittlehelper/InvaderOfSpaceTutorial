using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] GameObject bulletPrefab;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        print("boa");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + movement * speed * Time.fixedDeltaTime;
    }
}
