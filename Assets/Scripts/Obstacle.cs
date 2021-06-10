using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField]
    private float _speedX = -80f;

    private Rigidbody2D _rigidBody;


    private Kite _kite;

  

    

    private void Awake()
    {
        _kite = GameObject.Find("Kite").GetComponent<Kite>();
        if (_kite == null)
        {
            Debug.LogError("Obstacle::_kite not found");
        }

        _rigidBody = GetComponent<Rigidbody2D>();
        if (_rigidBody == null)
        {
            Debug.LogError("Obstacle::RigidBody not found");
        }

        
       
    }
    
    private void Update()
    {

        if (_kite._dead == true)
        {
            _speedX = 0;
        }
        if (transform.position.x < -3.5)
            Destroy(this.gameObject);
    }
    void FixedUpdate()
    {


        _rigidBody.velocity = new Vector2(_speedX * Time.deltaTime, _rigidBody.velocity.y);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Kite")
        {
            collision.collider.GetComponent<Kite>().isDead();


        }
    }


}
