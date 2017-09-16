using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace WhiteCat.Tween
{
	/// <summary>
	/// Color 类型的插值动画
	/// </summary>
	public abstract class TweenColor : TweenFromTo<Color>
	{
		[SerializeField]
		Gradient _gradient = new Gradient();


		/// <summary> 是否使用渐变 </summary>
		public bool useGradient = false;

		/// <summary> RGB 动画开关. 仅用于非渐变 </summary>
		public bool toggleRGB = true;

		/// <summary> Alpha 动画开关. 仅用于非渐变 </summary>
		public bool toggleAlpha = true;


		/// <summary> 渐变 </summary>
		public Gradient gradient
		{
			get { return _gradient; }
		}


		// 根据插值系数更改插值状态
		public override void OnTween(float factor)
		{
			if (useGradient)
			{
				current = _gradient.Evaluate(factor);
			}
			else
			{
				var temp = current;

				if (toggleRGB)
				{
					temp.r = (_to.r - _from.r) * factor + _from.r;
					temp.g = (_to.g - _from.g) * factor + _from.g;
					temp.b = (_to.b - _from.b) * factor + _from.b;
				}

				if (toggleAlpha)
				{
					temp.a = (_to.a - _from.a) * factor + _from.a;
				}

				current = temp;
			}
		}

#if UNITY_EDITOR

		SerializedProperty _useGradientProperty;
		SerializedProperty _toggleRGBProperty;
		SerializedProperty _toggleAlphaProperty;
		SerializedProperty _fromProperty;
		SerializedProperty _toProperty;
		SerializedProperty _fromAlphaProperty;
		SerializedProperty _toAlphaProperty;
		SerializedProperty _gradientProperty;


		protected override void Editor_OnEnable()
		{
			base.Editor_OnEnable();

			_useGradientProperty = editor.serializedObject.FindProperty("useGradient");
			_toggleRGBProperty = editor.serializedObject.FindProperty("toggleRGB");
			_toggleAlphaProperty = editor.serializedObject.FindProperty("toggleAlpha");
			_fromProperty = editor.serializedObject.FindProperty("_from");
			_toProperty = editor.serializedObject.FindProperty("_to");
			_fromAlphaProperty = _fromProperty.FindPropertyRelative("a");
			_toAlphaProperty = _toProperty.FindPropertyRelative("a");
			_gradientProperty = editor.serializedObject.FindProperty("_gradient");
		}


		protected override void Editor_OnDisable()
		{
			base.Editor_OnDisable();

			_useGradientProperty = null;
			_toggleRGBProperty = null;
			_toggleAlphaProperty = null;
			_fromProperty = null;
			_toProperty = null;
			_fromAlphaProperty = null;
			_toAlphaProperty = null;
			_gradientProperty = null;
		}


		protected override void DrawExtraFields()
		{
			EditorGUILayout.PropertyField(_useGradientProperty);

			if (useGradient)
			{
				EditorGUI.indentLevel++;
				EditorGUILayout.PropertyField(_gradientProperty);
				EditorGUI.indentLevel--;
			}
			else
			{
				EditorGUILayout.Space();
				ColorRGBField(_toggleRGBProperty, _fromProperty, _toProperty);
				ClampedFloatChannelField(_toggleAlphaProperty, "A", _fromAlphaProperty, _toAlphaProperty, 0f, 1f);
			}
		}

#endif // UNITY_EDITOR

	} // class TweenColor

} // namespace WhiteCat.Tween