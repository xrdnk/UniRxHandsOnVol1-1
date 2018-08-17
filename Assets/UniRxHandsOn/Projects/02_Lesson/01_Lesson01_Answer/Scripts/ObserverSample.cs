using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_01_Answer
{
	public class ObserverSample : MonoBehaviour
	{
		[SerializeField] private SubjectSample m_SubjectSample = null;

		private void Awake()
		{
			// Subjectの購読及び、振る舞い定義
			m_SubjectSample.m_Subject
				.Subscribe( ( x ) => Debug.Log( x ) );


			// 重要: Subjectの実体を外部に公開してしまうと
			//		 下記のようなコードが通ってしまうため危険。
			//		 よりBetterな解答例は、本ディレクトリの「Better」を参照
			// m_SubjectSample.m_Subject.OnNext( 1 );	// Observer側が勝手にメッセージを送信できてしまうため、
														// どこからメッセージが発生しているのか分からなくなる

			// m_SubjectSample.m_Subject = null;		// Observer側が勝手にSubjectを抹消できてしまう
		}
	}
}
