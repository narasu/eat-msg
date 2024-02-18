using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[SaveDuringPlay][AddComponentMenu("")][ExecuteAlways]
public class CameraRollLock : CinemachineExtension
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            Vector3 e = vcam.LookAt.eulerAngles;
            state.RawOrientation = Quaternion.Euler(.0f, e.y, .0f);
            
        }
    }
}
