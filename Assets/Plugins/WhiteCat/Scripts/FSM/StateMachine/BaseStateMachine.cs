
namespace WhiteCat.FSM
{
	/// <summary>
	/// 状态机基类. 需要继承并调用 UpdateCurrentState 来更新当前状态
	/// </summary>
	public abstract class BaseStateMachine : ScriptableComponent
	{
		IState _currentState;
		float _currentStateTime;


		/// <summary>
		/// 当前状态持续时间
		/// </summary>
		public float currentStateTime
		{
			get { return _currentStateTime; }
		}


		/// <summary>
		/// 当前状态
		/// </summary>
		public IState currentState
		{
			get { return _currentState; }
			set
			{
				if (_currentState != null)
				{
					_currentState.OnExit();
				}

				Kit.Swap(ref value, ref _currentState);
				_currentStateTime = 0;

				if (_currentState != null)
				{
					_currentState.OnEnter();
				}

				OnStateChanged(value, _currentState);
			}
		}


		/// <summary>
		/// 当前状态组件. 用于序列化事件
		/// </summary>
		public BaseState currentStateComponent
		{
			get { return _currentState as BaseState; }
			set { currentState = value; }
		}


		/// <summary>
		/// 调用以更新当前状态
		/// </summary>
		protected void UpdateCurrentState(float deltaTime)
		{
			_currentStateTime += deltaTime;
			if (_currentState != null)
			{
				_currentState.OnUpdate(deltaTime);
			}
		}


		/// <summary>
		/// 状态变化后触发的事件
		/// </summary>
		protected virtual void OnStateChanged(IState prevState, IState currentState)
		{
		}

	} // class BaseStateMachine

} // namespace WhiteCat.FSM