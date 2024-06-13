using System;
using UnityEngine;

public class TableTouching : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JengaPiece")){
            _gameManager.piecesTouching++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("JengaPiece"))
        { 
            _gameManager.piecesTouching--;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.piecesTouching >= 5)
        {
            _gameManager.GameOver();
        }
    }
}
