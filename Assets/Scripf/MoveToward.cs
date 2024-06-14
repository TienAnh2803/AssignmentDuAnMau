using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveToward : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(arrow, spawnPoint.position,transform.rotation);
        }           
    }
}
