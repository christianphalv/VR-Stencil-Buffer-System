using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilMask : MonoBehaviour {

    private Renderer _renderer;
    private Section _nextSection;

    public void initializeStencilMask(Section nextSection) {

        // Initialize properties
        _renderer = GetComponent<Renderer>();
        _nextSection = nextSection;

        // Set stencil reference for next section
        _renderer.material.SetInt("_StencilRef", _nextSection.getId());
    }

}
