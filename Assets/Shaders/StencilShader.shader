Shader "Stencil/Mask" {

    Properties{
        [IntRange] _StencilRef("Stencil ID", Range(0,255)) = 0
    }

    SubShader {
        Tags { 
            "RenderType" = "Opaque" 
            "RenderPipeline" = "UniversalRenderPipeline" 
            "Queue" = "Geometry"
        }

        Pass {

            Blend Zero One
            ZWrite Off

            Stencil {
                Ref[_StencilRef]
                Comp Always
                Pass Replace
                Fail Keep
            }
        }
    }
}