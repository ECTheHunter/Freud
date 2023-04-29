using DG.Tweening;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public void StartHover()
    {
        transform.DOScale(1.2f, 0.5f);
    }

    public void EndHover()
    {
        transform.DOScale(1, 0.5f);
    }
}
