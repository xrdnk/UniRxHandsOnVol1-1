using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace UniRxHandsOn.Lesson_04_Answer
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
			// 上下左右(Horizontal & Vertical)キーのInputEvent登録
			this.UpdateAsObservable()
				.Select( _ => new Vector3( Input.GetAxis( HORIZONTAL ), 0, Input.GetAxis( VERTICAL ) ) )
				.Subscribe( x => m_MoveDir.SetValueAndForceNotify( x ) );	// SetValueAndForceNotify()で、代入した値が
																			// 前回値から変化していない場合でも強制的に
																			// メッセージを送信する事ができる

			// ジャンプ(Space)キーのInputEvent登録
			this.UpdateAsObservable()
				.Select( _ => Input.GetKeyDown( KeyCode.Space ) )
				.Subscribe( x => m_Jump.Value = x );

			// しゃがみ(C)キーのInputEvent登録
			this.UpdateAsObservable()
				.Select( _ => Input.GetKey( KeyCode.C ) )
				.Subscribe( x => m_Crouch.Value = x );

			// 歩き(LeftShift)キーのInputEvent登録
			this.UpdateAsObservable()
				.Select( _ => Input.GetKey( KeyCode.LeftShift ) )
				.Subscribe( x => m_Walk.Value = x );
		}
	}
}
