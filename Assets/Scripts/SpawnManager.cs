using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{


    [SerializeField]
    private GameObject _obstaclePrefab;
    [SerializeField]
    private GameObject _obstacleAtRewardPrefab;

    [SerializeField]
    private GameObject _obstacleContainer;

    private float _highScore, _countForHS = 1;
  
    private Transform _camera;

    private bool _playerDead = false;

    private float _polePos = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _camera = GameObject.Find("Main Camera").GetComponent<Transform>();

        if(_camera == null)
        {
            Debug.LogError("SpawnManager:: Main Camera :: Transform not found");
        }
        StartCoroutine(spawnObsacle());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator spawnObsacle()
    {

        while(!_playerDead)
        {
            
            Vector3 spawnPos = new Vector3(3.5f, Random.Range(-.8f,2.65f), 0);
            if (_countForHS == _highScore)
            {
                GameObject obstaclesAtReward = Instantiate(_obstacleAtRewardPrefab, spawnPos, Quaternion.identity) as GameObject;

                obstaclesAtReward.transform.Find("PoleDown").GetComponent<Transform>().position =
                   new Vector3(obstaclesAtReward.transform.Find("PoleDown").GetComponent<Transform>().position.x, -_polePos +
                   obstaclesAtReward.transform.position.y, 0);
                obstaclesAtReward.transform.Find("PoleUp").GetComponent<Transform>().position =
                   new Vector3(obstaclesAtReward.transform.Find("PoleDown").GetComponent<Transform>().position.x, _polePos +
                   obstaclesAtReward.transform.position.y, 0);

              //  obstaclesAtReward.transform.parent = _obstacleContainer;
            }
            else
            {


                GameObject obstacles = Instantiate(_obstaclePrefab, spawnPos, Quaternion.identity) as GameObject;

                obstacles.transform.Find("PoleDown").GetComponent<Transform>().position =
                   new Vector3(obstacles.transform.Find("PoleDown").GetComponent<Transform>().position.x, -_polePos +
                   obstacles.transform.position.y, 0);
                obstacles.transform.Find("PoleUp").GetComponent<Transform>().position =
                   new Vector3(obstacles.transform.Find("PoleDown").GetComponent<Transform>().position.x, _polePos +
                   obstacles.transform.position.y, 0);

              //  obstacles.transform.parent = _obstacleContainer;
            }
            
            yield return new WaitForSeconds(3);

            ++_countForHS;

            if(_polePos > 3.93)
                _polePos -= 0.045f;
        }
    }

    public void onPlayerDeath()
    {
        _playerDead = true;
    }
}
