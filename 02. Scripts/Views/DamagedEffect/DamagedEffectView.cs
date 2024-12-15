using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    public class DamagedEffectView : ViewBase
    {
        public enum ImageKey
        {
            WarningImage,
            BloodImage,
        }

        Coroutine _waringEffect;
        Coroutine _bloodEffect;

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
        }

        public void PlayEffect(float warningDuration, float warningFadeOutDuration,
            float bloodDuration, float bloodFadeOutDuration)
        {
            if (_waringEffect != null)
                StopCoroutine(_waringEffect);
                
            if (_bloodEffect != null)
                StopCoroutine(_bloodEffect);


            _waringEffect = StartCoroutine(EffectAnim(GetImage((int)ImageKey.WarningImage), warningDuration, warningFadeOutDuration));
            _bloodEffect = StartCoroutine(EffectAnim(GetImage((int)ImageKey.BloodImage), bloodDuration, bloodFadeOutDuration));
        }

        IEnumerator EffectAnim(Image image, float duration, float fadeOutDuration)
        {
            image.gameObject.SetActive(true);

            Color color = image.color;
            color.a = 1;
            image.color = color;

            yield return new WaitForSeconds(duration);

            float elapsedTime = 0;
            while(elapsedTime < fadeOutDuration)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                color.a = 1 - elapsedTime / fadeOutDuration;
                image.color = color;
            }

            image.gameObject.SetActive(false);
            color.a = 1;
            image.color = color;
        }
    }
}
