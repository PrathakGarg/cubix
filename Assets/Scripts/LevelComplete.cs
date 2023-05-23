using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Jump")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
