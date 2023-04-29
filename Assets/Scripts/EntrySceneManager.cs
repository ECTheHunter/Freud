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
        _dialogueController.StartDialog();
    }

    private void OnDisable()
    {
        _dialogueController.OnDialogCompleted -= OnDialogComplete;
    }

    private void OnDialogComplete()
    {
        _transitionImage.DOFade(1, 1.5f).OnComplete(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        });
    }
}
