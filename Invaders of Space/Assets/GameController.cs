using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<8;i=i+1)
        {
            Instantiate(enemyPrefab, new Vector3(-7+i*2, 3, 0), Quaternion.identity);
        }
        InvokeRepeating("MoveEnemies", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveEnemies()
    {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.transform.position = enemy.transform.position + new Vector3(horizontalSpeed, 0, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            horizontalSpeed = -horizontalSpeed;
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.transform.position = enemy.transform.position+new Vector3(0, verticalSpeed, 0);
            }
            if(GameObject.FindGameObjectWithTag("Enemy").transform.position.y<-3.5f)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
