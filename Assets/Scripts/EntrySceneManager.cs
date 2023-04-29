using DG.Tweening;
using UnityEngine;

public class EntrySceneManager : MonoBehaviour
{
    [SerializeField] private DialogueController _dialogueController;
    [SerializeField] private UnityEngine.UI.Image _transitionImage;

    private void OnEnable()
    {
        _dialogueController.OnDialogCompleted += OnDialogComplete;
    }

    private void Start()
    {
        TransitionManager.Instance.OpenBlackPanels(OnTransition);
    }

    private void OnDisable()
    {
        _dialogueController.OnDialogCompleted -= OnDialogComplete;
    }

    private void OnTransition()
    {
        _dialogueController.StartDialog();
    }

    private void OnDialogComplete()
    {
        TransitionManager.Instance.OpenWhiteTransition(() => UnityEngine.SceneManagement.SceneManager.LoadScene(2));
    }
}
