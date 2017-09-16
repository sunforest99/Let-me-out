#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
#endif

namespace WhiteCat.Tween
{
	/// <summary>
	/// float 类型的插值动画
	/// </summary>
	public abstract class TweenFloat : TweenFromTo<float>
	{
		// 根据插值系数更改插值状态
		public override void OnTween(float factor)
		{
			current = (_to - _from) * factor + _from;
		}

#if UNITY_EDITOR

		SerializedProperty _fromProperty;
		SerializedProperty _toProperty;


		protected override void Editor_OnEnable()
		{
			base.Editor_OnEnable();

			_fromProperty = editor.serializedObject.FindProperty("_from");
			_toProperty = editor.serializedObject.FindProperty("_to");
		}


		protected override void Editor_OnDisable()
		{
			base.Editor_OnDisable();
			_fromProperty = null;
			_toProperty = null;
		}


		protected override void DrawExtraFields()
		{
			DrawFromToValues();
        }


		protected void DrawFromToValues()
		{
			EditorGUILayout.PropertyField(_fromProperty);
			EditorGUILayout.PropertyField(_toProperty);
		}


		protected void DrawClampedFromToValues(float min, float max)
		{
			_fromProperty.floatValue = Mathf.Clamp(EditorGUILayout.FloatField("From", _fromProperty.floatValue), min, max);
			_toProperty.floatValue = Mathf.Clamp(EditorGUILayout.FloatField("To", _toProperty.floatValue), min, max);
		}


		protected void DrawClampedFromToValuesWithSlider(float min, float max)
		{
			_fromProperty.floatValue = EditorGUILayout.Slider("From", _fromProperty.floatValue, min, max);
			_toProperty.floatValue = EditorGUILayout.Slider("To", _toProperty.floatValue, min, max);
		}

#endif // UNITY_EDITOR

	} // class TweenFloat

} // namespace WhiteCat.Tween