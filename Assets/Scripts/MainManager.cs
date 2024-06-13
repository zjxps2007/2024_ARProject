using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour{
    public Dropdown gameList;
    private int dropDownValue = 0;
    public Button btnStart;
    public Button btnExit;
    public Button btnCredits;

    public Scene JengaGame;

    void Start()
    {
        gameList.onValueChanged.AddListener(delegate { UpdateDropdownValue(); });
        dropDownValue = gameList.value;
        btnStart.onClick.AddListener(StartGame);
        btnExit.onClick.AddListener(ExitApp);
        btnCredits.onClick.AddListener(Credits);
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (dropDownValue == 0)
        {
            //start Jenga
            SceneManager.LoadScene(sceneName:"JengaGame");

        }
        else if (dropDownValue == 1)
        {
            //start Clue
            //SceneManager.LoadScene("ClueGame");


        }
        else if (dropDownValue == 2)
        {
            //start sliding puzzle
            //SceneManager.LoadScene("PuzzleGame");


        }
        else if (dropDownValue == 3)
        {
            //start maze
            //SceneManager.LoadScene("MazeGame");


        }

        //SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);

    }

    public void UpdateDropdownValue()
    {
        dropDownValue = gameList.value;

    }

    public void ExitApp()
    {
        Application.Quit();

    }

    public void Credits()
    {


    }

}
