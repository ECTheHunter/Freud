using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance { get; private set; }

    [SerializeField] private GameObject _upPanel;
    [SerializeField] private GameObject _downPanel;
    [SerializeField] private AudioSource _blackPanelAudio;

    [Header("White Panel")]
    [SerializeField] private Image _whitePanel;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _upPanel.SetActive(false);
        _downPanel.SetActive(false);
        _whitePanel.gameObject.SetActive(false);
    }

    public void CloseBlackPanels(Action onComplete)
    {
        Sequence sequence1 = DOTween.Sequence();
        _upPanel.SetActive(true);
        _downPanel.SetActive(true);
        //sequence1.Append(_upPanel.transform.DOLocalMoveY(450, 0.5f).OnComplete(() =>
        //{
        //    _blackPanelAudio.Play();
        //}));
        //sequence1.Append(_downPanel.transform.DOLocalMoveY(-450, 0.5f).OnComplete(() =>
        //{
        //    _blackPanelAudio.Play();
        //})); 
        //sequence1.OnComplete(() =>
        //{
        //    onComplete?.Invoke();
        //});
        _downPanel.transform.DOLocalMoveY(-450, 0.5f);
        _upPanel.transform.DOLocalMoveY(450, 0.5f).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void OpenBlackPanels(Action onComplete)
    {
        //Sequence sequence1 = DOTween.Sequence();
        //sequence1.Append(_downPanel.transform.DOLocalMoveY(-1060, 0.5f));
        //sequence1.Append(_upPanel.transform.DOLocalMoveY(1060, 0.5f));
        //sequence1.OnComplete(() =>
        //{
        //    _downPanel.SetActive(false);
        //    _upPanel.SetActive(false);
        //    onComplete?.Invoke();
        //});
        _downPanel.transform.DOLocalMoveY(-1060, 0.6f);
        _upPanel.transform.DOLocalMoveY(1060, 0.6f).OnComplete(() =>
        {
            _downPanel.SetActive(false);
            _upPanel.SetActive(false);
            onComplete?.Invoke();
        });
    }

    public void OpenWhiteTransition(Action onComplete)
    {
        _whitePanel.gameObject.SetActive(true);
        _blackPanelAudio.Play();
        _whitePanel.DOFade(1, 5).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void CloseWhiteTransition(Action onComplete)
    {
        _whitePanel.DOFade(0, 1).OnComplete(() => {
            _whitePanel.gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }
}
