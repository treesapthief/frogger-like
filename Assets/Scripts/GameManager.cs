using UnityEngine;

public enum GameState
{
    //NewGame,
    //WaitForStart,
    InGame,
    Paused,
    PlayerDied,
    GameOver,
    LevelComplete
}

public delegate void OnStateChangeHandler(GameState newState);

public class GameManager : MonoBehaviour
{
    public event OnStateChangeHandler OnStateChange;
    public GameState GameState { get; private set; }

    private static GameManager _instance = null;

    protected GameManager()
    {
        _instance = this;
    }

    public void SetGameState(GameState state)
    {
        Debug.Log($"GameState changed: {state}");
        GameState = state;
        OnStateChange?.Invoke(state);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetGameState(GameState.InGame);
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameState == GameState.GameOver && Input.anyKeyDown)
        //{
        //    SetGameState(GameState.InGame);
        //}
        //else if (GameState == GameState.PlayerDied && Input.anyKeyDown)
        //{
        //    SetGameState(GameState.InGame);
        //}
    }
    public static GameManager Instance
    {
        get
        {
            //if (_instance == null)
            //{
            //    _instance = new GameManager();
            //}

            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }
}
