
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using static Common.EnumClass;

namespace Loading
{
    public class LoadingScene : MonoBehaviour
    {
        private const float RotateDuration = 10.0f;
        private const float RotateAngle = 360.0f;
        
        [SerializeField] private Image dimImage;
        [SerializeField] private Image loadingIcon;

        private Color _color = Color.white;

        private void Start()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName($"{SceneName.Loading}"));
            
            
            RotateIcon();
            SetAlpha(0.0f, true);
            SetAlpha(1.0f);
            
            // var color = Color.black;
            // color.a =  0.0f;
            // dimImage
            //     .DOColor(color, 0.0f)
            //     .SetEase(Ease.Linear);
        }

        public void Fade(bool isFadeOut)
        {
            var color = Color.black;
            color.a = isFadeOut ? 1.0f : 0.0f;
            
            dimImage
                .DOColor(color, 1.0f)
                .SetEase(Ease.Linear);
        }

        private void SetAlpha(float toAlpha, bool isInit = false)
        {
            _color.a = toAlpha;
           
            loadingIcon
                .DOColor(_color, isInit ? 0.0f : 1.0f)
                .SetEase(Ease.Linear);
        }
        
        private void RotateIcon()
        {
            loadingIcon.rectTransform
                .DORotate(new Vector3(0.0f, 0.0f, RotateAngle), RotateDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }
    }
}