using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ImpossibleSpaceManager : MonoBehaviour {

    public int _startingSectionID = 1;
    private Player _player;

    private Section[] _sections;
    private Section _currentSection;

    private Portal[] _portals;

    void Start() {

        // Initialize propterties
        _sections = GetComponentsInChildren<Section>();
        _player = FindObjectOfType<Player>();
        _portals = GetComponentsInChildren<Portal>();

        // Initialize sections
        foreach (Section section in _sections) {
            section.initializeSection(_player, this);
        }

        //
        foreach (Portal portal in _portals) {
            portal.initializePortal(_player, this);
        }

        // Activate starting section
        _currentSection = getSectionById(_startingSectionID);
        _currentSection.activateSection();

    }


    void Update() {

    }

    public void changeSection(Section nextSection) {
        _currentSection.deactivateSection();
        _currentSection = nextSection;
        _currentSection.activateSection();
    }

    Section getSectionById(int id) {
        foreach (Section section in _sections) {
            if (section.getId() == id) {
                return section;
            }
        }
        return null;
    }
}
