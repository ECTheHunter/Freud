using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buttonGroup;
    [SerializeField] private Image _blackScreenImage;
    [SerializeField] private Image _dialogImage;
    [SerializeField] private DialogueController _dialogueController;
    public AudioSource audioSource;

    private void OnEnable()
    {
        _dialogueController.OnDialogCompleted += OnDialogComplete;
        PlayerController.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _dialogueController.OnDialogCompleted -= OnDialogComplete;
        PlayerController.OnPlayerDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        OpenDeathScene();
    }

    private void OnDialogComplete()
    {
        _buttonGroup.DOFade(1, 1.5f);
        Cursor.lockState = CursorLockMode.None;
    }

    [ContextMenu("Open Death Screen")]
    public void OpenDeathScene()
    {
        _blackScreenImage.gameObject.SetActive(true);
        _dialogImage.gameObject.SetActive(false);
        _blackScreenImage.DOFade(1, 1.5f).OnComplete(() =>
        {
            //_dialogueController.StartDialog();
            TransitionManager.Instance.CloseBlackPanels(() =>
            {
                _blackScreenImage.gameObject.SetActive(false);
                _dialogImage.gameObject.SetActive(true);
                audioSource.time = 0.5f;
                audioSource.Play();
                TransitionManager.Instance.OpenBlackPanels(() =>
                {
                    _dialogueController.StartDialog();
                });
            });
        });
    }

    public void RetryLevel()
    {
        TransitionManager.Instance.OpenWhiteTransition(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    public void QuitGame()
    {
        TransitionManager.Instance.OpenBlackPanels(() =>
        {
            Application.Quit();
        });
    }
}
