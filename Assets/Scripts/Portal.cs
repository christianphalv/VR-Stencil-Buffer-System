using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Section _section0;
    public Section _section1;

    private ImpossibleSpaceManager _impossibleSpaceManager;
    private StencilMask[] _stencilMasks;
    private Section[] _sections;
    private Player _player;

    public void initializePortal(Player player, ImpossibleSpaceManager ISM) {

        // Initialize properties
        _impossibleSpaceManager = ISM;
        _player = player;
        _stencilMasks = GetComponentsInChildren<StencilMask>();
        _sections = new Section[2];
        _sections[0] = _section0;
        _sections[1] = _section1;
        _player = player;

        //
        _stencilMasks[0].initializeStencilMask(_sections[1]);
        _stencilMasks[1].initializeStencilMask(_sections[0]);

    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<Player>()) {
            if (Vector3.Dot(_player.getVelocity().normalized, this.transform.forward) < 0) {
                _impossibleSpaceManager.changeSection(_sections[0]);
            } else if (Vector3.Dot(_player.getVelocity().normalized, this.transform.forward) > 0) {
                _impossibleSpaceManager.changeSection(_sections[1]);
            }
        }
    }


    public void activatePortal() {

        // Enable rigidbody
        GetComponent<Rigidbody>().detectCollisions = true;

    }

    public void deactivatePortal() {

        // Disable rigidbody
        GetComponent<Rigidbody>().detectCollisions = false;
    }

    /*

    public ImpossibleSpaceManager _impossibleSpaceManager;
    public Section _nextSection;

    private Player _player;
    private Section _section;
    private Renderer _renderer;

    void Start() {

    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player>()) {
            if (Vector3.Dot(_player.getVelocity().normalized, this.transform.forward) > 0) {
                _impossibleSpaceManager.changeSection(_nextSection);
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<Player>()) {
            if (Vector3.Dot(_player.getVelocity().normalized, this.transform.forward) > 0) {
                //_impossibleSpaceManager.changeSection(_nextSection);
            }
        }
    }

    private void OnDestroy() {
        
    }

    public void initializePortal(Player player) {

        // Initialize properties
        _section = GetComponentInParent<Section>();
        _renderer = GetComponent<Renderer>();
        _player = player;

        // Set stencil reference for next section
        _renderer.material.SetInt("_StencilRef", _nextSection.getId());
    }

    public void activatePortal() {

        // Enable renderer
        //GetComponent<Renderer>().enabled = true;

        // Enable rigidbody
        GetComponent<Rigidbody>().detectCollisions = true;
        
    }

    public void deactivatePortal() {

        // Disable renderer
        //GetComponent<Renderer>().enabled = false;

        // Disable rigidbody
        GetComponent<Rigidbody>().detectCollisions = false;
    }
    */
}
