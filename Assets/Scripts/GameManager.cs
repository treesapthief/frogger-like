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
    public int Score = 0;
    public int HiScore = 0;
    public int Level = 1;
    private int _collectibleItem;

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

    public void CollectItem()
    {
        _collectibleItem--;
        if (_collectibleItem <= 0)
        {
            _collectibleItem = 0;
            SetGameState(GameState.LevelComplete);
        }
    }

    public void RestartLevel()
    {
        BuildCollectibleCount();
        SetGameState(GameState.InGame);
        // TODO: Should I set score here?
    }

    private void BuildCollectibleCount()
    {
        var collectibleItems = GameObject.FindGameObjectsWithTag("Collectible");
        _collectibleItem = collectibleItems.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        RestartLevel();
    }

    public static GameManager Instance
    {
        get
        {
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
