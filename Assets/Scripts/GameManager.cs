using System;
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
    public event Action<int> OnScoreChange;
    public event Action<int> OnHighScoreChange;
    public GameState GameState { get; private set; }
    public int BaseCollectibleScore = 100;

    private int _totalCollectibleItems;
    private int _itemsCollected;
    private int _score;
    private int _highScore;
    private int _level = 0;

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
        _itemsCollected++;

        var scoreGiven = BaseCollectibleScore * (int)Math.Pow(2, _level);
        GiveScore(scoreGiven);

        if (_itemsCollected >= _totalCollectibleItems )
        {
            _itemsCollected = _totalCollectibleItems;
            SetGameState(GameState.LevelComplete);
        }
    }

    public void RestartLevel()
    {
        BuildCollectibleCount();
        SetGameState(GameState.InGame);
        SetScore(0);
    }

    public void GiveScore(int score)
    {
        SetScore(_score + score);
    }

    private void SetScore(int score)
    {
        _score = score;
        OnScoreChange?.Invoke(score);

        // TODO: Move this to when the player completes a level, or a game over is reached
        // TODO: High Score only should change when the player is done playing
        // TODO: (and then set it in Player Prefs)
        if (_score > _highScore)
        {
            _highScore = _score;
            OnHighScoreChange?.Invoke(_highScore);
        }
    }



    private void BuildCollectibleCount()
    {
        var collectibleItems = GameObject.FindGameObjectsWithTag("Collectible");
        _itemsCollected = 0;
        _totalCollectibleItems = collectibleItems.Length;
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
