using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JengaManager : Singleton<JengaManager>
{
    //Jenga Stuff
    public GameObject table;
    public GameObject jengaPiece;
    public Vector3 spawnPoint;
    private float pieceOffsetZ = 0.25f;
    private float pieceOffsetY = 0.15f;
    public int layers = 9;
    private int currentLayer;
    private float spawnDelay = 0.1f;
    public string jengaPieceTag = "JengaPiece";

    [HideInInspector]
    public bool pieceSelected;
    public bool isPaused;
    public bool canMove;

    public int numOfPlayers;
    private bool gameInProgress;

    //Pause Stuff
    public Canvas PauseCanvas;
    //public PauseManager myPause;
    public Button startButton, ExitButton;

    protected JengaManager() { }
    
    private void Start()
    {
        PauseCanvas.enabled = false;

        startButton.onClick.AddListener(ResumeGame);
        ExitButton.onClick.AddListener(CloseGame);
        //settingsButton.onClick.AddListener(OpenSettings);
        table.GetComponent<TableTouching>().piecesTouching = 0;

        currentLayer = 0;
        pieceSelected = false;
        isPaused = false;
        gameInProgress = false;
        Time.timeScale = 1.0f;

        SpawnJengaPieces();
    }

    private void Update()
    {
        if (Input.GetKeyUp("p") || Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }

        if (!isPaused)
        {
            if (Input.GetKeyUp("r"))
            {
                ResetPieces();
            }

            if (Input.GetKeyUp("c"))
            {
                Camera.main.GetComponent<FlyCamera>().enabled = !Camera.main.GetComponent<FlyCamera>().enabled;
            }

            if (table.GetComponent<TableTouching>().piecesTouching >= 5)
            {
                GameOver();
            }
        }
    }

    public void SpawnJengaPieces()
    {
        if (currentLayer < layers)
        {
            if (currentLayer % 2 == 0)
            {
                SpawnHorizontalLayer(currentLayer);
            }
            else
            {
                SpawnVerticalLayer(currentLayer);
            }
            currentLayer++;
            Invoke("SpawnJengaPieces", spawnDelay);
        }

        gameInProgress = true;
    }
    private void SpawnHorizontalLayer(int layer)
    {
        Vector3 center = new Vector3(spawnPoint.x, spawnPoint.y + pieceOffsetY * layer, spawnPoint.z);
        Quaternion rotation = new Quaternion();
        Instantiate(jengaPiece, center, rotation);
        Instantiate(jengaPiece, new Vector3(center.x, center.y, center.z + pieceOffsetZ), rotation);
        Instantiate(jengaPiece, new Vector3(center.x, center.y, center.z - pieceOffsetZ), rotation);
    }
    private void SpawnVerticalLayer(int layer)
    {
        Vector3 center = new Vector3(spawnPoint.x, spawnPoint.y + pieceOffsetY * layer, spawnPoint.z);
        Quaternion rotation = Quaternion.Euler(0, 90, 0);
        Instantiate(jengaPiece, center, rotation);
        Instantiate(jengaPiece, new Vector3(center.x + pieceOffsetZ, center.y, center.z), rotation);
        Instantiate(jengaPiece, new Vector3(center.x - pieceOffsetZ, center.y, center.z), rotation);
    }

    public void ResetPieces()
    {
        ClearPieces();
        table.GetComponent<TableTouching>().piecesTouching = 0;
        currentLayer = 0;
        SpawnJengaPieces();
    }
    private void ClearPieces()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag(jengaPieceTag);
        foreach (GameObject piece in pieces)
        {
            Destroy(piece);
        }
    }

    private void GameOver()
    {
        PauseCanvas.enabled = true;
        canMove = false;
        gameInProgress = false;
        isPaused = true;
        Camera.main.GetComponent<FlyCamera>().enabled = false;
    }

    private void TogglePause() {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseGame();
        }
        if (!isPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseCanvas.enabled = true;
        canMove = false;
        Camera.main.GetComponent<FlyCamera>().enabled = false;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        PauseCanvas.enabled = false;
        canMove = true;
        isPaused = false;
        Camera.main.GetComponent<FlyCamera>().enabled = true;

        if (!gameInProgress)
        {
            ResetPieces();
            gameInProgress = true;
        }
    }

    public void CloseGame()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

}
