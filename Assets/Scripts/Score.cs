using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private HighScore highScore;
    private TMP_Text scoreText;

    private void Start()
    {
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<HighScore>();
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float score = player.position.z;
        if (score > highScore.highScore) highScore.highScore = score;

        scoreText.text = player.position.z.ToString("0");
    }
}
