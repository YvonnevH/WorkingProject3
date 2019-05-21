using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class LayerSetting : MonoBehaviour {

	// Use this for initialization
	void Awake () {
#if UNITY_EDITOR
        LayerUtil.CreateLayer("CameraDragLayer");
#endif
    }
}
