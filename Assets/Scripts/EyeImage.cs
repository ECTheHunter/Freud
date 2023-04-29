using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EyeImage : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        _anim.enabled = true;
    }
}
