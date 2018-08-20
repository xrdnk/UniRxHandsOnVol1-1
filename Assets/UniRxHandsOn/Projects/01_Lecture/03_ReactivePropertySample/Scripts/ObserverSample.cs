using UnityEngine;
using UniRx;

namespace UniRxHandsOn.ReactivePropertySample
{
	public class ObserverSample : MonoBehaviour
	{
		[SerializeField] private ReactivePropertySample m_ReactiveProperty = null;

		private void Awake()
		{
			// Subjectの購読及び、振る舞い定義
			m_ReactiveProperty.OnValueChanged
				.Subscribe( ( x ) => Debug.Log( x ) );
		}
	}
}
