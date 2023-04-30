using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private DialogueController _dialogController;
    [SerializeField] private CanvasGroup _bgAndName;
    [SerializeField] private CanvasGroup _credits;
    [SerializeField] private CanvasGroup _toBeContinuedText;
    [SerializeField] private Image _quitButton;

    private void Start()
    {
        TransitionManager.Instance.CloseWhiteTransition(() =>
        {
            _dialogController.StartDialog();
        });
    }

    private void OnEnable()
    {
        _dialogController.OnDialogCompleted += OnDialogCompleted;   
    }

    private void OnDialogCompleted()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_bgAndName.DOFade(1, 2.5f));
        seq.Append(_credits.DOFade(1, 1.5f));
        seq.Append(_credits.DOFade(1, 2.5f));
        seq.OnComplete(() =>
        {
            _quitButton.DOFade(1, 1f);
        });
    }
}
