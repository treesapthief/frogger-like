using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnHighScoreChange += OnHighScoreChanged;
    }

    private void OnHighScoreChanged(int score)
    {
        var scoreText = GetComponent<TMP_Text>();
        scoreText.text = $"HI Score: {score}";
    }
}
