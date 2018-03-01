using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SparkTools
{
    [AddComponentMenu("UI/Version Text", 99)]
    public class VersionText : Text
    {
        protected override void Awake()
        {
            base.Awake();

            if (Application.isPlaying)
            {
#if UNITY_EDITOR
                enabled = false;
                text = "automatic versioning is not available in the editor";
#else
            text = Application.version;
#endif
            }
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            text = "Version Number";
        }
#endif
    }
}