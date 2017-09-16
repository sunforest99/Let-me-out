using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
using WhiteCatEditor;
#endif

namespace WhiteCat
{
	/// <summary>
	/// 开关状态
	/// </summary>
	public enum ToggleState
	{
		Uninitialized = -1,		// 未初始化
		Off = 0,				// 关闭
		On = 1,					// 打开
	}


	/// <summary>
	/// 开关
	/// </summary>
	[AddComponentMenu("White Cat/Common/Toggle")]
	public class Toggle : ScriptableComponentWithEditor
	{
		[SerializeField][Range(0f, 1f)]
		float _criticalValue = 0.5f;

		[SerializeField][Range(0f, 1f)]
		float _defaultValue = 0f;

		[SerializeField]
		UnityEvent _turnOnCallback = new UnityEvent();

		[SerializeField]
		UnityEvent _turnOffCallback = new UnityEvent();

		ToggleState _state = ToggleState.Uninitialized;
		float _currentValue = 0f;


		/// <summary>
		/// 打开与关闭状态的临界值
		/// </summary>
		public float criticalValue
		{
			get { return _criticalValue; }
			set
			{
				value = Mathf.Clamp01(value);

				if (_criticalValue != value)
				{
					_criticalValue = value;

					if (_state == ToggleState.On)
					{
						if (_currentValue <= _criticalValue)
						{
							_state = ToggleState.Off;
							_turnOffCallback.Invoke();
						}
					}
					else if (_state == ToggleState.Off)
					{
						if (_currentValue >= _criticalValue)
						{
							_state = ToggleState.On;
							_turnOnCallback.Invoke();
						}
					}
				}
			}
		}


		/// <summary>
		/// 默认值. 应当在 Start 执行之前访问
		/// </summary>
		public float defaultValue
		{
			get { return _defaultValue; }
			set { _defaultValue = value; }
		}


		/// <summary>
		/// 当前值. 不应当在 Start 执行之前访问
		/// </summary>
		public float currentValue
		{
			get { return _currentValue; }
			set
			{
				value = Mathf.Clamp01(value);

				if (_currentValue != value)
				{
					_currentValue = value;

					if (_state == ToggleState.On)
					{
						if (_currentValue <= _criticalValue)
						{
							_state = ToggleState.Off;
							_turnOffCallback.Invoke();
						}
					}
					else if (_state == ToggleState.Off)
					{
						if (_currentValue >= _criticalValue)
						{
							_state = ToggleState.On;
							_turnOnCallback.Invoke();
						}
					}

#if UNITY_EDITOR
					if (editor) editor.Repaint();
#endif
				}
			}
		}


		/// <summary>
		/// 开关状态
		/// </summary>
		public ToggleState state
		{
			get { return _state; }
		}


		/// <summary>
		/// 打开的回调
		/// </summary>
		public event UnityAction turnOnCallback
		{
			add { _turnOnCallback.AddListener(value); }
			remove { _turnOnCallback.RemoveListener(value); }
		}


		/// <summary>
		/// 关闭的回调
		/// </summary>
		public event UnityAction turnOffCallback
		{
			add { _turnOffCallback.AddListener(value); }
			remove { _turnOffCallback.RemoveListener(value); }
		}


		/// <summary>
		/// 打开开关. 不应当在 Start 执行之前访问
		/// </summary>
		public void TurnOn()
		{
			currentValue = 1f;
		}


		/// <summary>
		/// 关闭开关. 不应当在 Start 执行之前访问
		/// </summary>
		public void TurnOff()
		{
			currentValue = 0f;
		}


		// 初始化
		void Start()
		{
			_currentValue = _defaultValue;

			if (_currentValue < _criticalValue)
			{
				_state = ToggleState.Off;
				_turnOffCallback.Invoke();
			}
			else
			{
				_state = ToggleState.On;
				_turnOnCallback.Invoke();
			}

#if UNITY_EDITOR
			if (editor) editor.Repaint();
#endif
		}


#if UNITY_EDITOR

		SerializedProperty _criticalValueProperty;
		SerializedProperty _defaultValueProperty;
		SerializedProperty _turnOnCallbackProperty;
		SerializedProperty _turnOffCallbackProperty;


		protected override void Editor_OnEnable()
		{
			_criticalValueProperty = editor.serializedObject.FindProperty("_criticalValue");
			_defaultValueProperty = editor.serializedObject.FindProperty("_defaultValue");
			_turnOnCallbackProperty = editor.serializedObject.FindProperty("_turnOnCallback");
			_turnOffCallbackProperty = editor.serializedObject.FindProperty("_turnOffCallback");
		}


		protected override void Editor_OnDisable()
		{
			_criticalValueProperty = null;
			_defaultValueProperty = null;
			_turnOnCallbackProperty = null;
			_turnOffCallbackProperty = null;
		}


		protected override void Editor_OnInspectorGUI()
		{
			editor.serializedObject.Update();

			if (Application.isPlaying && _state != ToggleState.Uninitialized)
			{
				EditorGUI.BeginChangeCheck();
				float value = EditorGUILayout.Slider("Critical Value", _criticalValue, 0f, 1f);
				if (EditorGUI.EndChangeCheck()) criticalValue = value;

				EditorGUI.BeginChangeCheck();
				EditorKit.RecordAndSetGUIBackgroundColor(_state == ToggleState.On ? Color.yellow : Color.cyan);
				value = EditorGUILayout.Slider("Current Value", _currentValue, 0f, 1f);
				EditorKit.RestoreGUIBackgroundColor();
				if (EditorGUI.EndChangeCheck()) currentValue = value;
			}
			else
			{
				EditorGUILayout.PropertyField(_criticalValueProperty);
				EditorGUILayout.PropertyField(_defaultValueProperty);
			}

			EditorGUILayout.PropertyField(_turnOnCallbackProperty);
			EditorGUILayout.PropertyField(_turnOffCallbackProperty);

			editor.serializedObject.ApplyModifiedProperties();
		}

#endif

	} // class Toggle

} // namespace WhiteCat