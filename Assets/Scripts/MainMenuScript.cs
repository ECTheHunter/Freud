using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void OnPressStart()
    {
        TransitionManager.Instance.CloseBlackPanels(LoadNextLevel);
    }

    public void OnPressQuit()
    {
        TransitionManager.Instance.CloseBlackPanels(() => Application.Quit());
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
