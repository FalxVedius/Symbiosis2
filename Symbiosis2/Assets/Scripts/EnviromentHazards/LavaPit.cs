using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaPit : MonoBehaviour
{
    public CanvasGroup gameOverGroup;
    public IEnumerator FadeInGameOver(CanvasGroup _canvasGroup, float _start, float _end, float _lerp = 1f)
    {
        float timeStartLerp = Time.time;
        float timeDelta = 0f;
        float percentComplete = 0f;

        while(true)
        {
            timeDelta = Time.time - timeStartLerp;
            percentComplete = timeDelta / _lerp;

            float currAlpha = Mathf.Lerp(_start, _end, percentComplete);

            _canvasGroup.alpha = currAlpha;

            if (percentComplete >= 1)
                    break;

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator ReloadToCheckpoint(CanvasGroup _canvasGroup, PlayerMovement _charMove)
    {
        yield return new WaitForSecondsRealtime(5.0f);

        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
        _charMove.Enabled = true;
        _canvasGroup.alpha = 0;
        Debug.Log("Reloading " + scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement charMovement = other.gameObject.GetComponentInParent<PlayerMovement>();

        if (charMovement != null)
        {
            charMovement.Enabled = false;

            StartCoroutine(FadeInGameOver(gameOverGroup, gameOverGroup.alpha, 1));

            StartCoroutine(ReloadToCheckpoint(gameOverGroup, charMovement));
        }

    }
}
