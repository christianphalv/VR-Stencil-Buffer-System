using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StencilFeature : ScriptableRendererFeature {


    [System.Serializable]
    public class StencilSettings {

        //
        public string passTag = "StencilFeature";
        public RenderPassEvent Event = RenderPassEvent.AfterRenderingOpaques;

        //
        [Range(1, 255)] public int stencilReference = 1;
    }

    //
    StencilPass pass;
    public StencilSettings passSettings = new StencilSettings();

    //
    public override void Create() {
        pass = new StencilPass(passSettings);
    }

    //
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) {
        renderer.EnqueuePass(pass);
    }

}
