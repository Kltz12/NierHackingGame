using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
