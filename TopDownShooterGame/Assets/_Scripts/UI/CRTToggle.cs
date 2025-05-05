using UnityEngine;
using UnityEngine.Rendering;

public class PipelineSwitcher : MonoBehaviour
{
    public RenderPipelineAsset pipelineWithCRT;
    public RenderPipelineAsset pipelineWithoutCRT;

    private bool isCRTEnabled = true;

    public void TogglePipeline()
    {
        isCRTEnabled = !isCRTEnabled;
        GraphicsSettings.defaultRenderPipeline = isCRTEnabled ? pipelineWithCRT : pipelineWithoutCRT;
    }
}
