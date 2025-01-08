using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 피해 효과를 시각적으로 표시하는 뷰.
    /// </summary>
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

        /// <summary>
        /// 피해 효과를 재생합니다.
        /// </summary>
        /// <param name="warningDuration">경고 효과 지속 시간.</param>
        /// <param name="warningFadeOutDuration">경고 효과 페이드 아웃 시간.</param>
        /// <param name="bloodDuration">피 효과 지속 시간.</param>
        /// <param name="bloodFadeOutDuration">피 효과 페이드 아웃 시간.</param>
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

            // 초기 알파값 설정
            Color color = image.color;
            color.a = 1;
            image.color = color;

            // 효과 지속 시간 동안 대기
            yield return new WaitForSeconds(duration);

            // 페이드 아웃 애니메이션
            float elapsedTime = 0;
            while(elapsedTime < fadeOutDuration)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                color.a = 1 - elapsedTime / fadeOutDuration;
                image.color = color;
            }

            // 효과 종료
            image.gameObject.SetActive(false);
            color.a = 1;
            image.color = color;
        }
    }
}
