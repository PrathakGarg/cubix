using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    [HideInInspector]
    public float highScore;

    private TMP_Text highScoreText;

    private void Awake()
    {
        highScore = PlayerPrefs.GetFloat("highscore" + SceneManager.GetActiveScene().buildIndex, 0);
    }

    void Start()
    {
        highScoreText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (highScore.ToString("0") != highScoreText.text) highScoreText.text = string.Format("Highscore: {0}", highScore.ToString("0"));
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("highscore" + SceneManager.GetActiveScene().buildIndex, highScore);
        PlayerPrefs.Save();
    }
}
