using DG.Tweening;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale = Vector3.one * 1.2f;
    [SerializeField] private float _scaleDuration = 0.5f;

    public void StartHover()
    {
        transform.DOScale(_targetScale, _scaleDuration);
    }

    public void EndHover()
    {
        transform.DOScale(1, _scaleDuration);
    }
}
