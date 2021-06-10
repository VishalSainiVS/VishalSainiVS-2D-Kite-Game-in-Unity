using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform _kite;

    private float _speed = 0.125f;
    private void Awake()
    {
        _kite = GameObject.Find("Kite").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPos = _kite.position;
        Vector3 smoothFollow = Vector3.Lerp(transform.position, desiredPos, _speed);
        if (_kite.position.x >= this.transform.position.x)
            transform.position = new Vector3(smoothFollow.x, transform.position.y, transform.position.z);




    }
}
