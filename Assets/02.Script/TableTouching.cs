using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableTouching : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI gameGUI;
    [SerializeField] private GameObject button;
    
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JengaPiece")){
            _gameManager.piecesTouching++;
            gameGUI.text = _gameManager.piecesTouching + " / 5";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("JengaPiece"))
        { 
            _gameManager.piecesTouching--;
            gameGUI.text = _gameManager.piecesTouching + " / 5";
        }
    }

    private void Update()
    {
        if (GameManager.Instance.piecesTouching >= 5)
        {
            _gameManager.GameOver();
            button.SetActive(true);
        }
    }

    public void OnGameOverButton()
    {
        _gameManager.piecesTouching = 0;
        Time.timeScale = 0;
        button.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
