
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Title
{
    public class TitleScene : MonoBehaviour
    {
        private const float OutAlpha = 0.2f;
        private const float Duration = 1.0f;
        private const float FastSpeedOffset = 0.9f;
        
        [SerializeField] private Text touchText;

        private float _speed;
        private bool _isFadeOut;
        private Button _touchButton;
        private Coroutine _fadeRoutine;
        private Color _color = Color.white;

        private void Awake()
        {
            _touchButton = touchText.GetComponent<Button>();
            
            _touchButton.onClick.RemoveAllListeners();
            
            _touchButton.onClick.AddListener(MoveToLobby);
        }

        private void Start()
        {
            Clear();
            _fadeRoutine = StartCoroutine(OnFade());
        }

        private IEnumerator OnFade()
        {
            while (true)
            {
                _color.a = OutAlpha;
                touchText.DOColor(_color, Duration - _speed).OnComplete(() => _isFadeOut = false);;
                
                yield return new WaitUntil(() => _isFadeOut is false);

                _color.a = 1.0f;
                touchText.DOColor(_color, Duration - _speed).OnComplete(() => _isFadeOut = true);
                
                yield return new WaitUntil(() => _isFadeOut);
            }
        }

        private void MoveToLobby()
        {
            _speed = FastSpeedOffset;
            
            Clear();
            _fadeRoutine = StartCoroutine(OnFade());
        }

        private void Clear()
        {
            if(_fadeRoutine is null) return;
            
            StopCoroutine(_fadeRoutine);
            _fadeRoutine = null;
        }
    }
}