using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
