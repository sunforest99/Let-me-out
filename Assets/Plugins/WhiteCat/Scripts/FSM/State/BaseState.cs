
namespace WhiteCat.FSM
{
	/// <summary>
	/// 状态组件基类
	/// </summary>
	public abstract class BaseState : ScriptableComponent, IState
	{
		public abstract void OnEnter();
		public abstract void OnExit();
		public abstract void OnUpdate(float deltaTime);
	}

} // namespace WhiteCat.FSM