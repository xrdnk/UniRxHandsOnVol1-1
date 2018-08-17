using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace UniRxHandsOn.Lesson_04
{
	public interface IInputEventProvider
	{
		IReadOnlyReactiveProperty<Vector3> MoveDir { get; }
		IReadOnlyReactiveProperty<bool> Jump { get; }
		IReadOnlyReactiveProperty<bool> Crouch { get; }
		IReadOnlyReactiveProperty<bool> Walk { get; }
	}

	public class InputEventProvider : MonoBehaviour, IInputEventProvider
	{
		private ReactiveProperty<Vector3> m_MoveDir = new ReactiveProperty<Vector3>();
		public IReadOnlyReactiveProperty<Vector3> MoveDir { get { return m_MoveDir; } }

		private ReactiveProperty<bool> m_Jump = new ReactiveProperty<bool>();
		public IReadOnlyReactiveProperty<bool> Jump { get { return m_Jump; } }

		private ReactiveProperty<bool> m_Crouch = new ReactiveProperty<bool>();
		public IReadOnlyReactiveProperty<bool> Crouch { get { return m_Crouch; } }

		private ReactiveProperty<bool> m_Walk = new ReactiveProperty<bool>();
		public IReadOnlyReactiveProperty<bool> Walk { get { return m_Walk; } }

		private static string HORIZONTAL = "Horizontal";
		private static string VERTICAL = "Vertical";


		private void Start()
		{
			// Sample: 上下左右(Horizontal & Vertical)キーのInputEvent登録
			this.UpdateAsObservable()
				.Select( _ => new Vector3( Input.GetAxis( HORIZONTAL ), 0, Input.GetAxis( VERTICAL ) ) )
				.Subscribe( x => m_MoveDir.SetValueAndForceNotify( x ) );

			// TODO: ジャンプ(Space)キーのInputEvent登録


			// TODO: しゃがみ(C)キーのInputEvent登録


			// TODO: 歩き(LeftShift)キーのInputEvent登録
			

		}
	}
}
