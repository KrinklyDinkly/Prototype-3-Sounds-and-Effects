using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;

    private float _startDelay = 2f;
    private float _repeatRate = 2f;
    private PlayerController _playerControllerScript;

    private Vector3 _spawnPosition = new Vector3(30, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

   private void SpawnObstacle()
    {
        if(_playerControllerScript.GameOver == false)
        {
            Instantiate(ObstaclePrefab, _spawnPosition, ObstaclePrefab.transform.rotation);
        }
    }
}
