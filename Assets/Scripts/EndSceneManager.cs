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
    [SerializeField] private TMPro.TextMeshProUGUI _toBeContinuedText;
    [SerializeField] private Image _quitButton;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        TransitionManager.Instance.CloseWhiteTransition(() =>
        {
            _dialogController.StartDialog();
            SoundManager.Instance.PlayMainTheme();
        });

        _quitButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void OnEnable()
    {
        _dialogController.OnDialogCompleted += OnDialogCompleted;   
    }

    [ContextMenu("On Dialog Complete")]
    public void OnDialogCompleted()
    {
        _canvas.sortingOrder = 3;
        Sequence seq = DOTween.Sequence();
        seq.Append(_bgAndName.DOFade(1, 2.5f));
        seq.Append(_credits.DOFade(1, 1.5f));
        seq.Append(_toBeContinuedText.DOFade(1, 2.5f));
        seq.Append(_quitButton.DOFade(1, 1f));
    }
}
