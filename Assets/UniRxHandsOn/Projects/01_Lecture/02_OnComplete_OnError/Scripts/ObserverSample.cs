using UniRx;
using UnityEngine;

namespace UniRxHandsOn.Lecture02 {
	public class ObserverSample : MonoBehaviour {
		[SerializeField] private SubjectSample m_SubjectSample = null;

		private void Awake () {
			// Subjectの購読及び、振る舞い定義
			m_SubjectSample.OnValueChanged
				.Subscribe (
					msg => Debug.Log ("OnNext:" + msg),
					error => Debug.Log ("OnError: " + error),
					() => Debug.Log ("OnCompleted"));
		}
	}
}