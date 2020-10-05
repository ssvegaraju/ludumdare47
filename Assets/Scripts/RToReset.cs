using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RToReset : MonoBehaviour
{

    private void Start() {
        FindObjectOfType<TextMeshProUGUI>().text += "\nTime: " + PlayerPrefs.GetString("time", "0:00s");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
