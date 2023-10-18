using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 30f;
    private PlayerController _playercontrollerscript;
    private float _leftbound = -15;

    // Start is called before the first frame update
    void Start()
    {
        _playercontrollerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playercontrollerscript.GameOver == false)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if(transform.position.x < _leftbound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
