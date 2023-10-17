
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static Common.EnumClass;

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
        private Coroutine _moveSceneRoutine;
        private Color _color = Color.white;

        private bool _isSelected;
        
        private void Awake()
        {
            _touchButton = touchText.GetComponent<Button>();
            
            _touchButton.onClick.RemoveAllListeners();
            
            _touchButton.onClick.AddListener(MoveToLobby);
        }

        private void Start()
        {
            //DOTween.KillAll();
            
            StartFade();
        }

        private IEnumerator OnFade()
        {
            while (true)
            {
                Fade(true);
                
                yield return new WaitUntil(() => _isFadeOut is false);

                Fade(false);
                
                yield return new WaitUntil(() => _isFadeOut);
            }
        }

        private void Fade(bool isFade)
        {
            _color.a = isFade ? OutAlpha : 1.0f;
            touchText.DOColor(_color, Duration - _speed).OnComplete(() => _isFadeOut = !isFade);;
        }
        
        private void MoveToLobby()
        {
            if(_isSelected) return;
            
            _isSelected = true;
            
            _speed = FastSpeedOffset;

            StartFade();
            StartCoroutine(MoveScene());
            
            IEnumerator MoveScene()
            {
                yield return new WaitForSeconds(1.0f);
                GameManager.Instance.SceneLoader.LoadScene(SceneName.Lobby);
            }
        }
        
        private void StartFade()
        {
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