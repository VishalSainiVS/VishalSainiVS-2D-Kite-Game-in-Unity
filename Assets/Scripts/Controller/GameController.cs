using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   

    public void restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void home()
    {
        SceneManager.LoadScene("Main Menu");
    }

  

}
