using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kite : MonoBehaviour
{
    [SerializeField]
    private float _speedY = 100f;
    private float _maxYSpeed = 300f;

    private Rigidbody2D _rigidBody;

    private float _angle = 0;
    private SpawnManager _spawnManager;

    [SerializeField]
    private AudioClip[] _audioClip;
    //public AudioSource _audioSouce;

    private UIManager _uiManager;

    public bool _dead = false;

    private AudioSource _audioSource;
    [SerializeField]
    private SoundManager _soundManager;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        _rigidBody = GetComponent<Rigidbody2D>();
        if (_rigidBody == null)
        {
            Debug.LogError("Kite::RigidBody not found");
        }
        
    }
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Kite:: Spawn Manager not found");
        }

     

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("ERROR::Kite::Canvas:: UiManager not found");
        }

       
        _audioSource = _soundManager._audioSource;
       
    }

    private void Update()
    {
        if(!_dead)
        {
            if (Input.touchCount > 0)
            {
                Time.timeScale = 1;
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {

                    
                    _audioSource.PlayOneShot(_audioClip[1]);
                }
            }
               
        }
        else if(_dead)
        {
            _spawnManager.onPlayerDeath();
            _uiManager.gameOver();
        }

    }

    void FixedUpdate()
    {

        if(!_dead)
        {
            consteraints();
            updateMovement();
        }
        
        
      

    }
    void consteraints()
    {

        if (transform.position.y > 4.65f)
        {
            transform.position = new Vector3(transform.position.x, 4.65f, transform.position.z);
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
        }
        else if (transform.position.x > -0.96 || transform.position.x < -0.96)
        {
            transform.position = new Vector3(-0.96f, transform.position.y, transform.position.z);

        }

        if (_rigidBody.velocity.y > 0)
        {
            if (_angle < 0)
                _angle += 1;

        }
        else if (_rigidBody.velocity.y < 0)
        {
            if (_angle > -90)
                _angle -= 1;
        }


        transform.rotation = Quaternion.Euler(Vector3.forward * _angle);

       

        /*if (Input.GetKeyDown(KeyCode.A))
            Time.timeScale = 1;*/
    }
    void updateMovement()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

           
          
            if (_speedY < _maxYSpeed)
            {
                _speedY += 3;
            }
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _speedY * Time.deltaTime);




        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (_speedY < _maxYSpeed)
        //    {
        //        _speedY += 3;
        //    }
        //    _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _speedY * Time.deltaTime);
        //}
        else
        {
            _speedY = 100f;
        }
    }
    public void isDead()
    {
       
        if(_dead == false)
            Vibration.Vibrate(100);
        _dead = true;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreUpdator"))
        {

            

            _uiManager.updateScore();

            
            //_audioSouce.PlayOneShot(_audioClip[0]);
            _audioSource.PlayOneShot(_audioClip[0]);
            collision.gameObject.SetActive(false);


        }
    }
    
}
