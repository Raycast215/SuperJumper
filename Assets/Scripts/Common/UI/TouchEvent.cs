
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI
{
    // Scripted by Raycast
    // 2023.10.17
    // 해당 오브젝트를 터치 클릭한 경우 이벤트를 발생시켜주는 클래스입니다.
    
    public class TouchEvent : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnTouched = delegate {  };
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnTouched.Invoke();
        }
    }
}