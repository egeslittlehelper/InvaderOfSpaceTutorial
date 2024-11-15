using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveUp", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }

    private void MoveUp()
    {
        transform.position = transform.position + new Vector3(0, speed, 0);
    }
}
