using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnScoreChange += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        var scoreText = GetComponent<TMP_Text>();
        scoreText.text = $"Score: {score}";
    }
}
