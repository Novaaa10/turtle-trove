using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject infopanel;
    public GameObject settingpanel;
    public GameObject garistigapanel;

    // Start is called before the first frame update
    void Start()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
        settingpanel.SetActive(false);
        garistigapanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton(string scenename) { 
      
        SceneManager.LoadScene(scenename);
    }

    public void InfoButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(true);
        settingpanel.SetActive(false);
        garistigapanel.SetActive(false);
    }
    public void SettingButton()
    {
        menupanel.SetActive(false);
        settingpanel.SetActive(true);
        infopanel.SetActive(false);
        garistigapanel.SetActive(false);
    }
    public void backbtton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
        settingpanel.SetActive(false);
        garistigapanel.SetActive(false);
    }
    public void quitbutton()
    {
        Application.Quit();
        Debug.Log("Tombol Keluar ditekan");
    }
    public void exitbutton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
        settingpanel.SetActive(false);
        garistigapanel.SetActive(false);
    }
}
