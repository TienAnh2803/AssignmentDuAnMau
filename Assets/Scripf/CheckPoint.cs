using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController gameController;
    public Transform respawnPoint;

    private SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    Collider2D coll;
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gameController.UpdateCheckPoint(respawnPoint.position);
            spriteRenderer.sprite = active;
            coll.enabled = false;
        }   
    }
}

