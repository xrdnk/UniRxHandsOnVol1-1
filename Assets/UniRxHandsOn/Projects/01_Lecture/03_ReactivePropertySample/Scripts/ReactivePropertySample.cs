using UnityEngine;
using UniRx;

namespace UniRxHandsOn.ReactivePropertySample
{
    public class ReactivePropertySample : MonoBehaviour
    {
        // ReactivePropertyの定義
        private ReactiveProperty<int> m_ReactiveProperty = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> OnValueChanged { get { return m_ReactiveProperty; } }

        private void Start()
        {
            // イベントの発火処理
            m_ReactiveProperty.Value = 1;
            m_ReactiveProperty.Value = 2;
            m_ReactiveProperty.Value = 3;
        }
    }
}
