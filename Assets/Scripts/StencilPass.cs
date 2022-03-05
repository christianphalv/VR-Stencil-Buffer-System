using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class StencilPass : ScriptableRenderPass {

    //
    ProfilingSampler m_ProfilingSampler;

    //
    const string profilerTag = "Stencil Pass";

    //
    StencilFeature.StencilSettings passSettings;

    //
    RenderTargetIdentifier x; // MAYBE STENCIL INFO GOES HERE????

    public StencilPass(StencilFeature.StencilSettings passSettings) {

        //
        this.passSettings = passSettings;

        //
        m_ProfilingSampler = new ProfilingSampler(profilerTag);
        renderPassEvent = passSettings.Event;
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData) {

        CommandBuffer cmd = CommandBufferPool.Get();
        using (new ProfilingScope(cmd, m_ProfilingSampler)) { 
            
        }
    }
}
