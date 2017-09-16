using UnityEngine;

namespace WhiteCat.FSM
{
	/// <summary>
	/// 通用状态机组件
	/// </summary>
	[AddComponentMenu("White Cat/FSM/State Machine")]
	public class StateMachine : BaseStateMachine
	{
		/// <summary>
		/// 状态机更新模式
		/// </summary>
		public UpdateMode updateMode = UpdateMode.Update;


		/// <summary>
		/// 初始状态
		/// </summary>
		public BaseState startState;


		// 设置初始状态
		void Start()
		{
			if (startState)
			{
				currentStateComponent = startState;
			}
		}


		// Update 更新状态
		void Update()
		{
			if (updateMode == UpdateMode.Update)
			{
				UpdateCurrentState(Time.deltaTime);
			}
		}


		// LateUpdate 更新状态
		void LateUpdate()
		{
			if (updateMode == UpdateMode.LateUpdate)
			{
				UpdateCurrentState(Time.deltaTime);
			}
		}


		// FixedUpdate 更新状态
		void FixedUpdate()
		{
			if (updateMode == UpdateMode.FixedUpdate)
			{
				UpdateCurrentState(Time.deltaTime);
			}
		}

	} // class StateMachine

} // namespace WhiteCat.FSM