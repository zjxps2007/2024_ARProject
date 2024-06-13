using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }
    
    public int piecesTouching = 0;
    public bool canMove;
    public bool pieceSelected;
    
    public void GameOver()
    {
        canMove = false;
    }
}
