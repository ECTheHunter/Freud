using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    [SerializeField, TextArea(0, 1000)] private string[] _dialogues;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private UnityEngine.UI.Image _transitionImage;
    [SerializeField] private float _delayBetweenLetters = 0.2f;

    private int _currentDialogIndex = 0;
    private bool _transitionStarted = false;
    private Coroutine _dialogRoutine;

    private void Start()
    {
        StartCoroutine(StartNextDialog());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(StartNextDialog());
    }

    public IEnumerator StartNextDialog()
    {
        if (_dialogRoutine != null)
        {
            StopCoroutine(_dialogRoutine);
            _currentDialogIndex++;
        }

        if (_currentDialogIndex < _dialogues.Length)
        {
            yield return _dialogRoutine =  StartCoroutine(StartDialog());
            _currentDialogIndex++;
        }
        else
        {
            StartTransition();
            _transitionStarted = true;
        }
    }
    
    private void StartTransition()
    {
        if (_transitionStarted == false)
        _transitionImage.DOFade(1, 1.5f).OnComplete(() => UnityEngine.SceneManagement.SceneManager.LoadScene(2));
    }

    private IEnumerator StartDialog()
    {
        _dialogueText.text = "";
        int letterIndex = 0;
        while (letterIndex < _dialogues[_currentDialogIndex].Length)
        {
            _dialogueText.text += _dialogues[_currentDialogIndex][letterIndex];
            letterIndex++;
            yield return new WaitForSeconds(_delayBetweenLetters);
        }
    }
}
