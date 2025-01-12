#if !ODIN_INSPECTOR

using UnityEditor;

namespace Zenject
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SceneContext))]
    [NoReflectionBaking]
    public class SceneContextEditor : RunnableContextEditor
    {
        SerializedProperty _contractNameProperty;
        SerializedProperty _parentNamesProperty;
        SerializedProperty _parentNewObjectsUnderSceneContextProperty;
        SerializedProperty _monoKernelProperty;

        public override void OnEnable()
        {
            base.OnEnable();

            _contractNameProperty = serializedObject.FindProperty("_contractNames");
            _parentNamesProperty = serializedObject.FindProperty("_parentContractNames");
            _parentNewObjectsUnderSceneContextProperty = serializedObject.FindProperty("_parentNewObjectsUnderSceneContext");
            _monoKernelProperty = serializedObject.FindProperty("_monoKernel");
        }

        protected override void OnGui()
        {
            base.OnGui();

            EditorGUILayout.PropertyField(_contractNameProperty, true);
            EditorGUILayout.PropertyField(_parentNamesProperty, true);
            EditorGUILayout.PropertyField(_parentNewObjectsUnderSceneContextProperty);
            EditorGUILayout.PropertyField(_monoKernelProperty);
        }
    }
}


#endif
