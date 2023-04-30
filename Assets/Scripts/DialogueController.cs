using TMPro;
using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private float _delayBetweenLetters = 0.2f;
    [SerializeField] private DialogueAsset _dialogAsset;
    public event System.Action OnDialogCompleted;

    private int _currentDialogIndex = 0;
    private bool _dialogStarted = false;
    private Coroutine _dialogRoutine;

    private void Update()
    {
        if (_dialogStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartNextDialog());
        }
    }

    [ContextMenu("Start Dialog")]
    public void StartDialog()
    {
        _dialogStarted = true;
        _currentDialogIndex = 0;
        _dialogBox.SetActive(true);
        StartCoroutine(StartNextDialog());
    }

    public IEnumerator StartNextDialog()
    {
        if (_dialogRoutine != null)
        {
            StopCoroutine(_dialogRoutine);
            _dialogueText.text = _dialogAsset.Dialogues[_currentDialogIndex];
            _currentDialogIndex++;
            _dialogRoutine = StartCoroutine(StartDialogCR());
        }
        else
        {
            yield return _dialogRoutine = StartCoroutine(StartDialogCR());
            _currentDialogIndex++;
            if (_currentDialogIndex >= _dialogAsset.Dialogues.Length)
            {
                FinishDialog();
            }
        }
    }

    private void FinishDialog()
    {
        if (_dialogStarted)
        {
            _dialogStarted = false;
            OnDialogCompleted?.Invoke();
        }
    }

    public void CloseDialog()
    {
        _dialogBox.SetActive(false);
    }

    private IEnumerator StartDialogCR()
    {
        if (_currentDialogIndex < _dialogAsset.Dialogues.Length)
        {
            _dialogueText.text = "";
            int letterIndex = 0;
            string[] left = _dialogAsset.Dialogues[_currentDialogIndex].Split(' ');
            letterIndex += left[0].Length;
            _dialogueText.text += left[0];
            while (letterIndex < _dialogAsset.Dialogues[_currentDialogIndex].Length)
            {
                _dialogueText.text += _dialogAsset.Dialogues[_currentDialogIndex][letterIndex];
                letterIndex++;
                yield return new WaitForSeconds(_delayBetweenLetters);
            }
        }
        else 
        {
            FinishDialog();
        }
    }
}
