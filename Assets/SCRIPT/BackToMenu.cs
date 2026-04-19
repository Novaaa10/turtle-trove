using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene(0);
    }
}