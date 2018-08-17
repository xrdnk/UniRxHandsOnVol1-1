using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_02
{
	public class OperatorSample : MonoBehaviour
	{
		[SerializeField] private ReactivePropertySample m_ReactiveProperty = null;

		private void Awake()
		{
			// TODO : 偶数のみ抽出し、抽出した数の二乗をログ出力する

		}
	}
}
