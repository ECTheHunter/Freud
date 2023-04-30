using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class EntrySceneManager : MonoBehaviour
{
    [SerializeField] private DialogueController _dialogueController;
    [SerializeField] private CanvasGroup _clockGroup;
    [SerializeField] Transform _clock;

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
        _clock.transform.DORotate(Vector3.forward * 20, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        _clockGroup.DOFade(1, 1f).OnComplete(() =>
        {
            DoFade();
        });
    }

    async void DoFade()
    {
        await Task.Delay(TimeSpan.FromSeconds(3.0f));
        TransitionManager.Instance.OpenWhiteTransition(() => UnityEngine.SceneManagement.SceneManager.LoadScene(2));
    }
}
