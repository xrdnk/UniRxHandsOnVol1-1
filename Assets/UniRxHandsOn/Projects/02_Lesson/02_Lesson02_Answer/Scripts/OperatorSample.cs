using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_02_Answer
{
	public class OperatorSample : MonoBehaviour
	{
		[SerializeField] private ReactivePropertySample m_ReactiveProperty = null;

		private void Awake()
		{
			m_ReactiveProperty.OnValueChanged
				.SkipLatestValueOnSubscribe()		// Skip(1)でも可。初期値をスキップする
				.Where( x => x % 2 == 0 )			// 偶数のみ抽出
				.Select( x => x * x )				// 抽出した偶数(x)を二乗する
				.Subscribe( ( x ) => Debug.Log( x ) );
		}
	}
}
