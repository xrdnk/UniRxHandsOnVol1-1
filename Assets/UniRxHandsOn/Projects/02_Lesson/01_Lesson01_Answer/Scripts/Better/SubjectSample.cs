using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_01_Answer.Better
{
	public class SubjectSample : MonoBehaviour
	{
		// Subjectの定義
		private Subject<int> m_Subject = new Subject<int>();

		// Subjectのうち、IObservableのIFだけ外部に公開することで、
		// 必要な機能を安全に公開することができる
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
