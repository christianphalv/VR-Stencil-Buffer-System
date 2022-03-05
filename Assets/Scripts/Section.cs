using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class Section : MonoBehaviour {

    public int _sectionNumber;
    public ForwardRendererData _forwardRendererData;
    public RenderObjects _stencilFeature;

    private Portal[] _portals;
    private Renderer[] _renderers;
    public bool _isActive;

    

    void Start() {

    }

    void Update() {

    }

    public void initializeSection(Player player, ImpossibleSpaceManager ISM) {

        _stencilFeature.settings.stencilSettings.stencilCompareFunction = CompareFunction.Equal;
        
        // Initialize properties
        _portals = GetComponentsInChildren<Portal>();
        _renderers = GetComponentsInChildren<Renderer>();

        // Set stencil ref for this section
        /*
        foreach (Renderer renderer in _renderers) {
            Material[] materials = renderer.materials;
            foreach (Material material in materials) {
                material.SetInt("_StencilRef", _sectionNumber);
            }
        }
        */

        // Initialize portals
        foreach (Portal portal in _portals) {
            portal.initializePortal(player, ISM);
        }

        // Deactivate by default
        deactivateSection();
        //EditorUtility.SetDirty(_stencilFeature);
        _forwardRendererData.SetDirty();
    }

    public void activateSection() {

        // Activate portals
        foreach (Portal portal in _portals) {
            portal.activatePortal();
        }

        // Activate materials
        _stencilFeature.settings.stencilSettings.stencilCompareFunction = CompareFunction.Always;


        /*
        foreach (Renderer renderer in _renderers) {
            Material[] materials = renderer.materials;
            foreach (Material material in materials) {
                material.SetInt("_StencilComp", (int) CompareFunction.Always);
            }
        }
        */

        // Set to active
        _isActive = true;
        //EditorUtility.SetDirty(_stencilFeature);
        _forwardRendererData.SetDirty();
    }

    public void deactivateSection() {

        // Deactivate portals
        foreach (Portal portal in _portals) {
            portal.deactivatePortal();
        }

        // Deactivate materials
        _stencilFeature.settings.stencilSettings.stencilCompareFunction = CompareFunction.Equal;

        /*
        foreach (Renderer renderer in _renderers) {
            Material[] materials = renderer.materials;
            foreach (Material material in materials) {
                material.SetInt("_StencilComp", (int) CompareFunction.Equal);
            }
        }
        */

        // Set to inactive
        _isActive = false;
        //EditorUtility.SetDirty(_stencilFeature);
        _forwardRendererData.SetDirty();
    }

    public int getId() {
        return _sectionNumber;
    }

    public bool isActive() {
        return _isActive;
    }


}
