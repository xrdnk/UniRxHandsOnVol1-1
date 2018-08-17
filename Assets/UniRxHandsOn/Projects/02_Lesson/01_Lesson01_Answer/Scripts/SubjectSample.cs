using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_01_Answer
{
	public class SubjectSample : MonoBehaviour
	{
		// Subjectの定義
		private Subject<int> m_Subject = new Subject<int>();
		public IObservable<int> OnValueChanged { get { return m_Subject; } }

		private void Start()
		{
			// イベントの発火処理
			m_Subject.OnNext( 1 );
			m_Subject.OnNext( 2 );
			m_Subject.OnNext( 3 );
		}
	}
}
