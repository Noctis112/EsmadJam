using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CutsceneController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera normalCamera;
    [SerializeField] CinemachineVirtualCamera cutsceneCamera;
    [SerializeField] float cutsceneDuration = 3f;

    private CinemachineBrain cameraBrain;

    void Start()
    {
        cameraBrain = GetComponent<CinemachineBrain>();
        // Set the normal camera as the active camera initially
        cameraBrain.m_DefaultBlend.m_Time = 0f;
        cameraBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        cameraBrain.m_DefaultBlend.m_BlendCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);
        cameraBrain.ActiveVirtualCamera = normalCamera;
    }

    void Update()
    {
        // Example: Trigger the cutscene camera for a few seconds when the spacebar key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TriggerCutscene());
        }
    }

    IEnumerator TriggerCutscene()
    {
        // Set the cutscene camera as the active camera and blend to it
        cameraBrain.m_DefaultBlend.m_Time = cutsceneDuration;
        cameraBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        cameraBrain.m_DefaultBlend.m_BlendCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);
        cameraBrain.ActiveVirtualCamera = cutsceneCamera;

        // Wait for the cutscene to finish
        yield return new WaitForSeconds(cutsceneDuration);

        // Switch back to the normal camera and blend to it
        cameraBrain.m_DefaultBlend.m_Time = 0f;
        cameraBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        cameraBrain.m_DefaultBlend.m_BlendCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);
        cameraBrain.ActiveVirtualCamera = normalCamera;
    }
}
