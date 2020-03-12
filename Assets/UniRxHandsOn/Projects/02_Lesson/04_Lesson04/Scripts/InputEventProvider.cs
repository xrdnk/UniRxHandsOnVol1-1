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
        private static string SPACE = "space";

        private void Start()
        {
            // Sample: 上下左右(Horizontal & Vertical)キーのInputEvent登録
            // TIPS: UpdateAsObservable()は、毎フレームメッセージを送信するためのストリームソース
            //		 要はUnityのUpdate()
            this.UpdateAsObservable()
                .Select(_ => new Vector3(Input.GetAxis(HORIZONTAL), 0, Input.GetAxis(VERTICAL)))
                .Subscribe(x => m_MoveDir.SetValueAndForceNotify(x));   // SetValueAndForceNotify()で、代入した値が
                                                                        // 前回値から変化していない場合でも強制的に
                                                                        // メッセージを送信する事ができる

            // TIPS: キーの取得方法
            // Input.GetKey( KeyCode ) : 指定したキー押下中は常にtrue, 離すとfalse
            // Input.GetKeyDown( KeyCode : 指定したキーを押下した時、そのフレームだけtrue, 以降はfalse
            // Input.GetKeyUp( KeyCode) : 指定したキーを離した時、そのフレームだけtrue, 以降はfalse

            // TODO: ジャンプ(Space)キーのInputEvent登録
            // 仕様: ジャンプキー押下でジャンプする。
            //		 ジャンプキー押しっぱなしの場合は1回だけジャンプする挙動とすること
            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(SPACE))
                .Subscribe(x => m_Jump.Value = x);

            // TODO: しゃがみ(C)キーのInputEvent登録
            // 仕様: しゃがみキー押下中はしゃがみ、離すと立つ
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.C))
                .Subscribe(x => m_Crouch.Value = x);

            // TODO: 歩き(LeftShift)キーのInputEvent登録
            // 仕様: 歩きキー + 上下左右キー押下中は歩く、歩きキーを離すと走る
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.LeftShift))
                .Subscribe(x => m_Walk.Value = x);

        }
    }
}
