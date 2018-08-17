using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_01_Answer.Better
{
	public class ObserverSample : MonoBehaviour
	{
		[SerializeField] private SubjectSample m_SubjectSample = null;

		private void Awake()
		{
			// Subjectの購読及び、振る舞い定義
			m_SubjectSample.OnValueChanged
				.Subscribe( ( x ) => Debug.Log( x ) );
		}
	}
}
