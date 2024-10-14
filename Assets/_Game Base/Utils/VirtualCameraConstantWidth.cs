using Unity.Cinemachine;
using UnityEngine;

public class VirtualCameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(1080, 1920);
    private CinemachineVirtualCamera componentCamera;
    private float targetAspect;
    private float initialFov;
    private float horizontalFov = 120f;

    private void Start()
    {
        componentCamera = GetComponent<CinemachineVirtualCamera>();

        targetAspect = DefaultResolution.x / DefaultResolution.y;

        initialFov = componentCamera.m_Lens.FieldOfView;
        horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
    }

    private void Update()
    {
        float aspect = Screen.width / (float)Screen.height;

        if (targetAspect <= aspect)
        {
            float constantWidthFov = CalcVerticalFov(horizontalFov, aspect);
            componentCamera.m_Lens.FieldOfView = constantWidthFov;
        }
        else
        {
            componentCamera.m_Lens.FieldOfView = initialFov;
        }
        
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }
}