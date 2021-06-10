using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    public Text _scoreText;

    [SerializeField]
    public Text _highScoreText;

    [SerializeField]
    public Text _yourScoreText;

    [SerializeField]
    private GameObject _gameOverPanel;


    public int _score = 0;
    public int _highScore;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverPanel.SetActive(false);

        _scoreText.text = "" + _score;

        _highScore =  PlayerPrefs.GetInt("HighScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "" + _score;
        _highScoreText.text = "High Score " + _highScore;

        _yourScoreText.text = "Your Score " + _score;
        //PlayerPrefs.DeleteAll();
        if(_score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = "High Score " + _score;
        }
    }


    public void updateScore()
    {
       
        _score += 1;
    }

    public void gameOver()
    {
        _gameOverPanel.SetActive(true);
    }
}
