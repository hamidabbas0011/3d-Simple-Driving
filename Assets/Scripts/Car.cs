using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _speedGainPerSecond = 1.0f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_speed<25)
        {
            _speed += _speedGainPerSecond * Time.deltaTime;
        }
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Steering(int value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            Debug.Log("Car Crashed");
            SceneManager.LoadScene(0);
            
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Game Finished");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
