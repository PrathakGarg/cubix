using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement movement;
    private GameManager manager;

    private readonly string OBSTACLE_TAG = "Obstacle";
    private readonly string JUMPER_TAG = "Jumper";
    private readonly string MANAGER_TAG = "GameController";
    private readonly string VICTORY_TAG = "Victory";

    private void GameOver()
    {
        movement.enabled = false;
        manager.EndGame();
    }

    private void Victory()
    {
        movement.enabled = false;
        manager.EndGame(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        manager = GameObject.FindGameObjectWithTag(MANAGER_TAG).GetComponent<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y < 0) GameOver();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(OBSTACLE_TAG)) GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(JUMPER_TAG)) movement.canJump = true;
        else if (other.gameObject.CompareTag(VICTORY_TAG)) Victory();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(JUMPER_TAG)) movement.canJump = false;
    }
}
