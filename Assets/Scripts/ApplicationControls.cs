using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationControls : MonoBehaviour {

    [SerializeField]
    Sprite fullScreenSprite;
    [SerializeField]
    Sprite exitFullScreenSprite;
    [SerializeField]
    GameObject fullScreenBtn;

  /*  private void Start()
    {
        if(Screen.fullScreenMode == UnityEngine.FullScreenMode.FullScreenWindow)
            fullScreenBtn.GetComponent<Image>().sprite = exitFullScreenSprite;
        else
            fullScreenBtn.GetComponent<Image>().sprite = fullScreenSprite;
    }

    void Update () {

        if (Input.GetKey("escape") && Screen.fullScreen)
        {
            Screen.fullScreenMode = UnityEngine.FullScreenMode.Windowed;
            fullScreenBtn.GetComponent<Image>().sprite = fullScreenSprite;
        }

    }

    public void FullScreenMode()
    {
        if (Screen.fullScreen)
        {
            fullScreenBtn.GetComponent<Image>().sprite = fullScreenSprite;
            Screen.fullScreenMode = UnityEngine.FullScreenMode.Windowed;
        }
        else
        {
            fullScreenBtn.GetComponent<Image>().sprite = exitFullScreenSprite;
            Screen.fullScreenMode = UnityEngine.FullScreenMode.FullScreenWindow;
        }
            

    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToVisualizer()
    {
        SceneManager.LoadScene(1);
    }*/

    public void Quit()
    {
        Application.Quit();
    }
}
