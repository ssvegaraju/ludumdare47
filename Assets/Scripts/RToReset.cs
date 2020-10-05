using UnityEngine;
using UnityEngine.SceneManagement;

public class RToReset : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
