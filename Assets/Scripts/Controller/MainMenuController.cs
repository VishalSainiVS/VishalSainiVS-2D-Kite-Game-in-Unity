using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    public Sprite _musicOn, _musicOff;
    
    
    public void sound()
    {
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            _image.sprite = _musicOn;
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            _image.sprite = _musicOff;
        }
        

    }
   public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {

            _image.sprite = _musicOff;
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {

            _image.sprite = _musicOn;
        }
    }
}
