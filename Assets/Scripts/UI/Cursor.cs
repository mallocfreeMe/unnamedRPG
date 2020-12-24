using System;
using UnityEngine;

namespace UI
{
    public class Cursor : MonoBehaviour
    {
        public Texture2D cursorArrow;

        private void Start()
        {
            UnityEngine.Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
