
using UnityEngine;

namespace Common.UI
{
    // Scripted by Raycast
    // 2023.10.17
    // 해당 contents의 rect 사이즈를 캔버스의 rect 사이즈만큼 변경해주는 클래스입니다.

    public class RectSizeSetter : MonoBehaviour
    {
        [SerializeField] private RectTransform canvasRect;
        [SerializeField] private RectTransform contents;
        
        private void LateUpdate()
        {
            // rect의 사이즈가 동일하다면 리턴.
            if(Mathf.Abs(canvasRect.rect.width).Equals(contents.sizeDelta.x)) return;

            // rect의 사이즈 변경.
            contents.sizeDelta = canvasRect.sizeDelta;
        }
    }
}