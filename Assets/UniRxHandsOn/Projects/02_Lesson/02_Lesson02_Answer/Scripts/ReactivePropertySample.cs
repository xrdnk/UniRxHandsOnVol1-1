using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_02_Answer
{
	public class ReactivePropertySample : MonoBehaviour
	{
		// ReactivePropertyの定義
		private ReactiveProperty<int> m_ReactiveProperty = new ReactiveProperty<int>();
		public IReadOnlyReactiveProperty<int> OnValueChanged { get { return m_ReactiveProperty; } }

		private void Start()
		{
			// イベントの発火処理
			for( int i = 0; i < 100; ++i )
			{
				m_ReactiveProperty.Value = i;
			}
		}
	}
}
