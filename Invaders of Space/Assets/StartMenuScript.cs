using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    GameObject SettingMenu;
    GameObject MainMenu;
    GameObject Title;
    GameObject StarsImage;
    [SerializeField] Sprite bigStar;
    [SerializeField] Sprite littleStar;
    public static float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        SettingMenu = GameObject.Find("SettingMenuCanvas");
        MainMenu = GameObject.Find("StartMenuCanvas");
        Title = GameObject.Find("Title");
        StarsImage = GameObject.Find("Stars");
        GameObject.Find("Slider").GetComponent<Slider>().value = volume;
        SettingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OpenSettingMenu()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void Back()
    {
        SettingMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void displayName()
    {
        Title.GetComponent<TMP_Text>().text = "Welcome " + GameObject.Find("InputField").GetComponent<TMP_InputField>().text;
        GameObject.Find("InputField").GetComponent<TMP_InputField>().text = "";
    }

    public void onSelect()
    {
        GameObject.Find("InputField").GetComponent<Image>().color = Color.blue;
        GameObject.Find("Placeholder").GetComponent<TMP_Text>().color = Color.white;
    }

    public void onDeselect()
    {
        GameObject.Find("InputField").GetComponent<Image>().color = Color.white;
    }

    public void toggleStars()
    {
        if (GameObject.Find("Toggle").GetComponent<Toggle>().isOn)
        {
            StarsImage.SetActive(true);
        }
        else
        {
            StarsImage.SetActive(false);
        }
    }

    public void changeSoundVolume()
    {
        volume = GameObject.Find("Slider").GetComponent<Slider>().value;
        GameObject.Find("Music").GetComponent<AudioSource>().volume = volume;
    }

    public void changeStars()
    {
        if (GameObject.Find("Dropdown").GetComponentInChildren<TMP_Text>().text.Equals("BigStar"))
        {
            GameObject.Find("Stars").GetComponent<Image>().sprite = bigStar;
        }
        else if (GameObject.Find("Dropdown").GetComponentInChildren<TMP_Text>().text.Equals("LittleStar"))
        {
            GameObject.Find("Stars").GetComponent<Image>().sprite = littleStar;
        }
    }
}
