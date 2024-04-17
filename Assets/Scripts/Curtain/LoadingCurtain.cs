using System.Collections;
using UnityEngine;

namespace Curtain
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private float _minShowTime;
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private float _fadeSpeed;
        [SerializeField] private GameObject _curtainCanvas;

        public void Show()
        {
            _curtainCanvas.SetActive(false);
            _curtain.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(_minShowTime);
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= _fadeSpeed;
                yield return new WaitForFixedUpdate();
            }

            _curtainCanvas.SetActive(false);
        }
    }
}