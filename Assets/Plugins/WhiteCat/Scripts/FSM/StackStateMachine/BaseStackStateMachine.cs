using System.Collections.Generic;

namespace WhiteCat.FSM
{
	/// <summary>
	/// 栈状态机基类. 需要继承并调用 UpdateCurrentState 来更新当前状态
	/// </summary>
	public abstract class BaseStackStateMachine : ScriptableComponent
	{
		IStackState _currentState;
		float _currentStateTime;
		Stack<IStackState> _states = new Stack<IStackState>(8);


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
		public IStackState currentState
		{
			get { return _currentState; }
		}


		/// <summary>
		/// 栈中状态的总数. 包括压入的空状态
		/// </summary>
		public int stateCount
		{
			get { return _states.Count; }
		}


		/// <summary>
		/// 将新状态压入栈
		/// </summary>
		public void PushState(IStackState newState)
		{
			if (_currentState != null)
			{
				_currentState.OnExit();
			}

			Kit.Swap(ref _currentState, ref newState);
			_currentStateTime = 0;
			_states.Push(_currentState);

			if (_currentState != null)
			{
				_currentState.OnPush();
                _currentState.OnEnter();
			}

			OnStateChanged(newState, _currentState);
		}


		/// <summary>
		/// 将新状态压入栈. 用于序列化事件
		/// </summary>
		public void PushStateComponent(BaseStackState newState)
		{
			PushState(newState);
        }


		/// <summary>
		/// 将当前状态弹出栈
		/// </summary>
		public void PopState()
		{
			PopStates(1);
		}


		/// <summary>
		/// 连续弹出多个状态
		/// </summary>
		public void PopStates(int count)
		{
			if (count > _states.Count) count = _states.Count;
			if (count <= 0) return;

			if (_currentState != null)
			{
				_currentState.OnExit();
			}

			IStackState state;
			while(count > 0)
			{
				state = _states.Pop();

				if (state != null) state.OnPop();

				count--;
			}

			state = _currentState;
			_currentState = (_states.Count > 0) ? _states.Peek() : null;
			_currentStateTime = 0f;

			if (_currentState != null)
			{
				_currentState.OnEnter();
			}

			OnStateChanged(state, _currentState);
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
		protected virtual void OnStateChanged(IStackState prevState, IStackState currentState)
		{
		}

	} // class BaseStackStateMachine

} // namespace WhiteCat.FSM