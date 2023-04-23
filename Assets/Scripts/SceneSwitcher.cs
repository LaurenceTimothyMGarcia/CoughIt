using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void CPPLibrary()
    {
        SceneManager.LoadScene("Library");
    }

    public void TestScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
