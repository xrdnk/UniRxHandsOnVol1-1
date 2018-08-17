using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_01_Answer
{
	public class ObserverSample : MonoBehaviour
	{
		[SerializeField] private SubjectSample m_Subject = null;

		private void Awake()
		{
			// Subjectの購読及び、振る舞い定義
			m_Subject.OnValueChanged
				.Subscribe( ( x ) => Debug.Log( x ) );
		}
	}
}
