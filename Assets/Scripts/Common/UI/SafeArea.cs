
using UnityEngine;

namespace Common.UI
{
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _rect;
        private Rect _safeArea;
        private Vector2 _minAnchor;
        private Vector2 _maxAnchor;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            _safeArea = Screen.safeArea;
            _minAnchor = _safeArea.position;
            _maxAnchor = _minAnchor + _safeArea.size;

            _minAnchor.x /= Screen.width;
            _minAnchor.y /= Screen.height;
            _maxAnchor.x /= Screen.width;
            _maxAnchor.y /= Screen.height;

            _rect.anchorMin = _minAnchor;
            _rect.anchorMax = _maxAnchor;
        }
    }
}