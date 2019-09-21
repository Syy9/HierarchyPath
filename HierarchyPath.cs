using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Syy.Tools
{
    public static class HierarchyPath
    {
        [MenuItem("GameObject/Copy Path", false, 21)]
        public static void CopyPath()
        {
            if (Selection.activeObject == null)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            EditorGUIUtility.systemCopyBuffer = GetPath(Selection.activeGameObject, sb).ToString();
        }

        private static StringBuilder GetPath(GameObject obj, StringBuilder sb)
        {
            if (obj == null)
            {
                return sb;
            }

            sb.Insert(0, "/" + obj.name);
            return GetPath(obj.transform.parent?.gameObject, sb);
        }
    }
}
