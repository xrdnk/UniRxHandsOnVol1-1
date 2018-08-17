using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UniRx;
using UniRx.Triggers;

namespace UniRxHandsOn.Lesson_04
{
	[RequireComponent(typeof(ThirdPersonCharacter), typeof(IInputEventProvider))]
	public class ThirdPersonUserControl : MonoBehaviour
	{
		private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
		private Transform m_Cam;                  // A reference to the main camera in the scenes transform
		private Vector3 m_CamForward;             // The current forward direction of the camera
		private Vector3 m_Move;
		private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
		private bool m_Crouch;
		private bool m_Walk;

		private IInputEventProvider m_InputProvider = null;

		private void GetComponents()
		{
			// get the transform of the main camera
			if( Camera.main != null )
			{
				m_Cam = Camera.main.transform;
			}
			else
			{
				Debug.LogWarning(
					"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject );
				// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
			}

			// get the third person character ( this should never be null due to require component )
			m_Character = GetComponent<ThirdPersonCharacter>();
		}

		private void Start()
		{
			GetComponents();

			SubscribeInputEvents();

			// 移動処理の委譲
			this.UpdateAsObservable()
				.Subscribe( x => m_Character.Move( ( m_Walk ) ? m_Move *= 0.5f : m_Move, m_Crouch, m_Jump ) );
		}

		private void SubscribeInputEvents()
		{
			m_InputProvider = GetComponent<IInputEventProvider>();

			// 上下左右キーの入力イベントを受け取り、結果をm_Moveに保持する
			m_InputProvider.MoveDir
				.Subscribe( axis =>
				{
					if( m_Cam != null )
					{
						// calculate camera relative direction to move:
						m_CamForward = Vector3.Scale( m_Cam.forward, new Vector3( 1, 0, 1 ) ).normalized;
						m_Move = axis.z * m_CamForward + axis.x * m_Cam.right;
					}
					else
					{
						// we use world-relative directions in the case of no main camera
						m_Move = axis.z * Vector3.forward + axis.x * Vector3.right;
					}
				} );

			// ジャンプキーの入力イベントを受け取り、結果をm_Jumpに保持する
			m_InputProvider.Jump
				.Subscribe( is_jump => m_Jump = is_jump );

			// しゃがみキーの入力イベントを受け取り、結果をm_Crouchに保持する
			m_InputProvider.Crouch
				.Subscribe( is_crouch => m_Crouch = is_crouch );

			m_InputProvider.Walk
				.Subscribe( is_walk => m_Walk = is_walk );
		}
	}
}
