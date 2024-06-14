using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{

    public GameObject rock;
    private float startDelay = 1f;
    private float deLay = 2.0f;

    void Start()
    {
        InvokeRepeating("SpawnTrap", startDelay, deLay);
    }

    // Update is called once per frame
    void Update()
    {

       

    }
    void SpawnTrap()
    {
        Instantiate(rock, transform.position, rock.transform.rotation);
    }
}
