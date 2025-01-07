using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// ���� ȿ���� �ð������� ǥ���ϴ� ��.
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
        /// ���� ȿ���� ����մϴ�.
        /// </summary>
        /// <param name="warningDuration">��� ȿ�� ���� �ð�.</param>
        /// <param name="warningFadeOutDuration">��� ȿ�� ���̵� �ƿ� �ð�.</param>
        /// <param name="bloodDuration">�� ȿ�� ���� �ð�.</param>
        /// <param name="bloodFadeOutDuration">�� ȿ�� ���̵� �ƿ� �ð�.</param>
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

            // �ʱ� ���İ� ����
            Color color = image.color;
            color.a = 1;
            image.color = color;

            // ȿ�� ���� �ð� ���� ���
            yield return new WaitForSeconds(duration);

            // ���̵� �ƿ� �ִϸ��̼�
            float elapsedTime = 0;
            while(elapsedTime < fadeOutDuration)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                color.a = 1 - elapsedTime / fadeOutDuration;
                image.color = color;
            }

            // ȿ�� ����
            image.gameObject.SetActive(false);
            color.a = 1;
            image.color = color;
        }
    }
}
