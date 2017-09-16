using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using WhiteCatEditor;
#endif

namespace WhiteCat
{
	/// <summary>
	/// 带类型的联合体
	/// </summary>
	[Serializable]
	public struct TypedUnionValue
	{
		public BasicValueTypes type;
		public UnionValue data;
	}


#if UNITY_EDITOR

	[CustomPropertyDrawer(typeof(TypedUnionValue))]
	class TypedUnionValueDrawer : BasePropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUIUtility.singleLineHeight;
		}


		public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
		{
			var field = GetFieldValue<TypedUnionValue>(property);
			EditorGUI.BeginChangeCheck();

			float typeWidth = (rect.width - EditorGUIUtility.labelWidth - 4f) * 0.5f;
			rect.width -= typeWidth + 4f;

			switch (field.type)
			{
				case BasicValueTypes.Bool:
					field.data.boolValue = EditorGUI.Toggle(rect, label, field.data.boolValue);
					break;

				case BasicValueTypes.SByte:
					field.data.sbyteValue = (sbyte)Mathf.Clamp(EditorGUI.IntField(rect, label, field.data.sbyteValue), sbyte.MinValue, sbyte.MaxValue);
					break;

				case BasicValueTypes.Byte:
					field.data.byteValue = (byte)Mathf.Clamp(EditorGUI.IntField(rect, label, field.data.byteValue), byte.MinValue, byte.MaxValue);
					break;

				case BasicValueTypes.Char:
					var text = EditorGUI.TextField(rect, label, field.data.charValue.ToString());
					field.data.charValue = text.Length > 0 ? text[0] : '\0';
                    break;

				case BasicValueTypes.Short:
					field.data.shortValue = (short)Mathf.Clamp(EditorGUI.IntField(rect, label, field.data.shortValue), short.MinValue, short.MaxValue);
					break;

				case BasicValueTypes.UShort:
					field.data.ushortValue = (ushort)Mathf.Clamp(EditorGUI.IntField(rect, label, field.data.ushortValue), ushort.MinValue, ushort.MaxValue);
					break;

				case BasicValueTypes.Int:
					field.data.intValue = EditorGUI.IntField(rect, label, field.data.intValue);
					break;

				case BasicValueTypes.UInt:
					long longValue = EditorGUI.LongField(rect, label, field.data.uintValue);
					field.data.uintValue = longValue < uint.MinValue ? uint.MinValue : (longValue > uint.MaxValue ? uint.MaxValue : (uint)longValue);
                    break;

				case BasicValueTypes.Long:
					field.data.longValue = EditorGUI.LongField(rect, label, field.data.longValue);
					break;

				case BasicValueTypes.ULong:
					field.data.ulongValue = (ulong)EditorGUI.LongField(rect, label, (long)field.data.ulongValue);
					break;

				case BasicValueTypes.Float:
					field.data.floatValue = EditorGUI.FloatField(rect, label, field.data.floatValue);
					break;

				case BasicValueTypes.Double:
					field.data.doubleValue = EditorGUI.DoubleField(rect, label, field.data.doubleValue);
					break;
			}

			rect.x = rect.xMax + 4f;
			rect.width = typeWidth;

			Enum type = EditorGUI.EnumPopup(rect, GUIContent.none, field.type);

			if (EditorGUI.EndChangeCheck())
			{
				var target = property.serializedObject.targetObject;
				Undo.RecordObject(target, "TypedUnionValue");
				field.type = (BasicValueTypes)type;
                fieldInfo.SetValue(target, field);
				EditorUtility.SetDirty(target);
            }
		}

	} // TypedUnionValue

#endif // UNITY_EDITOR

} // namespace WhiteCat