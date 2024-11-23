using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    GameObject pauseMenu;
    GameObject pauseIcon;
    [SerializeField] GameObject enemyprefab;
    [SerializeField] List<GameObject> objects = new List<GameObject>();

    private void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenuCanvas");
        pauseIcon = GameObject.Find("PauseIcon");
        GameObject.Find("Music").GetComponent<AudioSource>().volume = StartMenuScript.volume;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        //pauseIcon.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Object"))
        {
            objects.Add(obj);
            obj.SetActive(false);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            objects.Add(obj);
            obj.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
        objects.Clear();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
