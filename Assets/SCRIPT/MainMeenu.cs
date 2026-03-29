using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    void Start() { 
    
    }
    void Update() { 
    
    }
   public void StartButton(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


}