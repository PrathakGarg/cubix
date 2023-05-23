using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isOver = false;

    [SerializeField]
    private GameObject victoryUI;

    [SerializeField]
    private float restartDelay = 2f;

    public void EndGame(bool victory = false)
    {
        if (!isOver)
        {
            isOver = true;

            if (!victory)
            {
                Debug.Log("Game Over!");
                Invoke(nameof(Restart), restartDelay);
            } else
            {
                Debug.Log("You WON!!!");
                Invoke(nameof(ActivateVictory), restartDelay - 0.4f);
            }
        }
    }

    private void ActivateVictory()
    {
        victoryUI.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
