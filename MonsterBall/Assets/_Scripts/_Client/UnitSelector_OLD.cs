/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterBall.Client
{
    public class UnitSelector_OLD : MonoBehaviour
    {
        public static UnitSelector_OLD Instance;

        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("More than one UnitSelector in scene!");
                return;
            }

            Instance = this;
        }

        public GameObject abilityButtonUI;

        private List<Monster> selectedUnits;

        public GameObject selectionSpritePrefab;
        public GameObject hoverSpritePrefab;
        private Dictionary<int, GameObject> selectionSprites;
        private Dictionary<int, GameObject> hoverSprites;

        public LayerMask unitLayerMask;
        public LayerMask groundLayerMask;
        private Camera cam;

        // Box select
        private bool dragSelect;
        private bool dragEligible;
        private Vector3 dragStartPos;
        private MeshCollider selectionBox;
        private HashSet<int> currentlyInBox; // int = unit ids

        // Double click LM tracker
        private (Monster unit, float time) lastSelect;
        private float lastQuickSelectTime;

        public bool IsUnitSelected
        {
            get { return selectedUnits.Count > 0; }
        }

        public Monster CurrentlySelected
        {
            get
            {
                if (selectedUnits == null || selectedUnits.Count < 1)
                {
                    return null;
                }

                return selectedUnits[0];
            }
        }

        public List<Monster> SelectedUnits => selectedUnits;

        void Start()
        {
            cam = Camera.main;

            selectedUnits = new List<Monster>();
            selectionSprites = new Dictionary<int, GameObject>();
            hoverSprites = new Dictionary<int, GameObject>();
            currentlyInBox = new HashSet<int>();

            dragSelect = false;
            selectionBox = null;
            lastQuickSelectTime = Time.time;
        }

        void Update()
        {
            // cleanup for box selection
            if (selectionBox != null)
            {
                Destroy(selectionBox);
                selectionBox = null;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (AbilityHandler.instance.IsAnythingQueued())
                {
                    AbilityHandler.instance.ClearQueues();
                }
                else
                {
                    DeselectAll();
                }
            }

            if (!AbilityHandler.instance.IsThrowQueued)
            {
                RaycastForHover(Input.mousePosition);
            }

            #region Quick Select

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Monster unit =
                    GameMaster.instance.GetFirstUnitControlledByPlayerSlot(
                        ConnectionManager.instance.MySlot
                    );

                if (unit != null)
                {
                    if (SelectedUnits.Count == 1 &&
                        SelectedUnits.Contains(unit))
                    {
                        if (Time.time - lastQuickSelectTime < 0.5)
                        {
                            cam.GetComponent<CameraController>()
                                .FocusOn(unit.transform.position);
                        }
                    }

                    lastQuickSelectTime = Time.time;
                    DeselectAll();
                    dragSelect = false;
                    SelectUnit(unit);
                    return;
                }
            }

            #endregion

            // mouse down callback
            if (Input.GetMouseButtonDown(0))
            {
                if (AbilityHandler.instance.IsAnythingQueued() ||
                    AbilityHandler.instance.AbilityJustUsed)
                {
                    dragEligible = false;
                    return;
                }

                dragEligible = true;
                dragStartPos = Input.mousePosition;
            }

            // while mouse down is held
            if (Input.GetMouseButton(0))
            {
                if (AbilityHandler.instance.IsAnythingQueued() ||
                    AbilityHandler.instance.AbilityJustUsed)
                {
                    dragEligible = false;
                    return;
                }

                if (dragEligible && Vector3.Distance(
                        dragStartPos,
                        Input.mousePosition
                    ) > 30f)
                {
                    dragSelect = true;
                    GenerateBoxSelectArea(Input.mousePosition);
                }
            }

            // mouse up callback
            if (Input.GetMouseButtonUp(0))
            {
                if (AbilityHandler.instance.AbilityJustUsed ||
                    AbilityHandler.instance.IsAnythingQueued())
                {
                    return;
                }

                if (!dragSelect || !dragEligible)
                {
                    ClickSelect(
                        Input.mousePosition,
                        Input.GetKey(KeyCode.LeftShift)
                    );
                }
                else
                {
                    dragSelect = false;

                    // shift to add onto existing
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        DeselectAll();
                    }

                    foreach (int _unitId in hoverSprites.Keys)
                    {
                        Monster unit = GameMaster.instance.GetUnitById(_unitId);
                        if (unit != null && ConnectionManager.instance.MySlot ==
                            unit.playerSlotNumber)
                        {
                            SelectUnit(unit);
                        }
                    }

                    ClearHovers();
                    currentlyInBox.Clear();
                }
            }
        }

        #region Box Select

        private void GenerateBoxSelectArea(Vector3 _currentMousePos)
        {
            selectionBox = gameObject.AddComponent<MeshCollider>();
            // corners of 2D selection box
            Vector2[] corners = getBoundingBox(dragStartPos, _currentMousePos);

            // vertices of meshcollider
            Vector3[] vertices = new Vector3[4];

            RaycastHit hit;

            for (int i = 0; i < 4; i++)
            {
                Ray ray = cam.ScreenPointToRay(corners[i]);

                if (Physics.Raycast(ray, out hit, 1000f, groundLayerMask))
                {
                    vertices[i] = new Vector3(hit.point.x, 0, hit.point.z);
                    Debug.DrawLine(
                        cam.ScreenToWorldPoint(corners[i]),
                        hit.point,
                        Color.red,
                        .1f
                    );
                }
            }

            generateSelectionMesh(vertices);
            selectionBox.convex = true;
            selectionBox.isTrigger = true;
        }

        private void OnGUI()
        {
            if (dragEligible && dragSelect)
            {
                var rect = SelectionBox.GetScreenRect(
                    dragStartPos,
                    Input.mousePosition
                );
                SelectionBox.DrawScreenRectBorder(
                    rect,
                    2,
                    new Color(1f, 1f, 1f)
                );
            }
        }

        // https://www.youtube.com/watch?v=OL1QgwaDsqo&t=398s
        private Vector2[] getBoundingBox(Vector2 _p1, Vector2 _p2)
        {
            Vector2 newP1;
            Vector2 newP2;
            Vector2 newP3;
            Vector2 newP4;

            if (_p1.x < _p2.x)
            { // if _p1 is to the left of _p2
                if (_p1.y > _p2.y)
                { // if _p1 is above _p2
                    newP1 = _p1;
                    newP2 = new Vector2(_p2.x, _p1.y);
                    newP3 = new Vector2(_p1.x, _p2.y);
                    newP4 = _p2;
                }
                else
                { // if _p1 is below _p2
                    newP1 = new Vector2(_p1.x, _p2.y);
                    newP2 = _p2;
                    newP3 = _p1;
                    newP4 = new Vector2(_p2.x, _p1.y);
                }
            }
            else
            { // if _p1 is to the right of _p2
                if (_p1.y > _p2.y)
                { // if _p1 is above _p2
                    newP1 = new Vector2(_p2.x, _p1.y);
                    newP2 = _p1;
                    newP3 = _p2;
                    newP4 = new Vector2(_p1.x, _p2.y);
                }
                else
                { // if _p1 is below _p2
                    newP1 = _p2;
                    newP2 = new Vector2(_p1.x, _p2.y);
                    newP3 = new Vector2(_p2.x, _p1.y);
                    newP4 = _p1;
                }
            }

            Vector2[] boxCorners =
            {
                newP1, newP2, newP3, newP4
            };
            return boxCorners;
        }

        private void generateSelectionMesh(Vector3[] _corners)
        {
            Vector3[] verts = new Vector3[8];
            int[] tris =
            {
                0,
                1,
                2,
                2,
                1,
                3,
                4,
                6,
                0,
                0,
                6,
                2,
                6,
                7,
                2,
                2,
                7,
                3,
                7,
                5,
                3,
                3,
                5,
                1,
                5,
                0,
                1,
                1,
                4,
                0,
                4,
                5,
                6,
                6,
                5,
                7
            };

            // bottom rectangle
            for (int i = 0; i < 4; i++)
            {
                verts[i] = _corners[i];
            }

            // top rectangle
            for (int i = 4; i < 8; i++)
            {
                verts[i] = _corners[i - 4] + Vector3.up * 10f;
            }

            Mesh generatedMesh = new Mesh();
            generatedMesh.vertices = verts;
            generatedMesh.triangles = tris;
            selectionBox.sharedMesh = generatedMesh;
        }

        private void OnTriggerStay(Collider other)
        {
            Monster unit = other.gameObject.GetComponent<Monster>();
            if (unit != null)
            {
                currentlyInBox.Add(
                    unit.unitId
                ); // see FixedUpdate() for explanation
                CreateHover(unit);
            }

        }

        void FixedUpdate()
        {
            // this is necessary because the OnTriggerExit isn't firing as expected when we adjust the mesh
            // FixedUpdate is always called before OnTriggerStay, so we update every unit's collision status with the selection box in OnTriggerStay

            if (dragSelect)
            {
                List<int> removed = new List<int>();
                foreach (int _unitId in hoverSprites.Keys)
                {
                    if (!currentlyInBox.Contains(_unitId))
                    {
                        RemoveHover(_unitId);
                        removed.Add(_unitId);
                    }
                }

                // we can't edit the hoverSprites dictionary while we're iterating on it
                foreach (int _unitId in removed)
                {
                    hoverSprites.Remove(_unitId);
                }

                currentlyInBox.Clear();
            }
        }

        #endregion

        #region Raycast Checks

        private void RaycastForHover(Vector2 _mousePos)
        {
            Ray ray = cam.ScreenPointToRay(_mousePos);
            Monster unitHit = RaycastPreferNotSelected(ray, 300f);

            if (unitHit != null)
            {
                if (!hoverSprites.ContainsKey(unitHit.unitId))
                {
                    ClearHovers();
                    CreateHover(unitHit);
                }

                return;
            }
            else if (!dragSelect)
            {
                ClearHovers();
            }
        }

        public Monster RaycastPreferNotSelected(Ray ray, float maxDistance)
        {
            RaycastHit[] hits = Physics.RaycastAll(
                ray,
                maxDistance,
                unitLayerMask
            );
            if (hits.Length == 0)
            {
                return null;
            }

            // first populate list with units that are not selected
            List<RaycastHit> unselectedUnitsHitList = new List<RaycastHit>();
            List<RaycastHit> selectedUnitsHitList = new List<RaycastHit>();
            foreach (RaycastHit hit in hits)
            {
                Monster unit = hit.collider.GetComponent<Monster>();

                if (unit != null)
                {
                    if (!SelectedUnits.Contains(unit))
                    {
                        unselectedUnitsHitList.Add(hit);
                    }
                    else
                    {
                        selectedUnitsHitList.Add(hit);
                    }
                }
            }

            List<RaycastHit> hitList;
            if (unselectedUnitsHitList.Count > 0)
            {
                hitList = unselectedUnitsHitList;
            }
            else if (selectedUnitsHitList.Count > 0)
            {
                hitList = selectedUnitsHitList;
            }
            else
            {
                return null;
            }

            float shortestDistance = Mathf.Infinity;
            Monster closestUnit = null;
            foreach (RaycastHit hit in hitList)
            {
                if (hit.distance < shortestDistance)
                {
                    shortestDistance = hit.distance;
                    closestUnit = hit.collider.GetComponent<Monster>();
                }
            }

            return closestUnit;
        }

        private void ClickSelect(Vector2 _mousePos, bool _shiftHeld)
        {
            Ray ray = cam.ScreenPointToRay(_mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200, unitLayerMask))
            {
                Monster unit = hit.collider.GetComponent<Monster>();

                if (unit != null)
                {
                    if (_shiftHeld)
                    {
                        if (selectedUnits.Contains(unit))
                        {
                            DeselectUnit(unit);
                        }
                        else
                        {
                            SelectUnit(unit);
                        }
                    }
                    else
                    {
                        DeselectAll();
                        SelectUnit(unit);

                        lastSelect =
                            (unit,
                                Time
                                    .time); // strictly for double click LM selection purposes
                    }
                }
            }
        }

        #endregion

        #region Selection and Deselection

        public void SelectUnit(Monster _unit)
        {
            // Select our unit
            if (!selectedUnits.Contains(_unit))
            {
                selectedUnits.Add(_unit);
            }

            if (lastSelect.unit == _unit &&
                (Time.time - lastSelect.time < 0.5) &&
                _unit.playerSlotNumber == ConnectionManager.instance.MySlot &&
                _unit.GetComponent<Lineman>() != null)
            {
                lastSelect.unit = null;
                SelectAllLinemen();
            }

            // Create the selection sprite
            if (!selectionSprites.ContainsKey(_unit.unitId))
            {
                GameObject sprite = Instantiate(
                    selectionSpritePrefab,
                    _unit.transform
                );
                selectionSprites.Add(_unit.unitId, sprite);
            }

            // Destroy hover sprite if exists
            if (hoverSprites.ContainsKey(_unit.unitId))
            {
                Destroy(hoverSprites[_unit.unitId].gameObject);
            }

            AbilityHandler.instance.ClearQueues();
            ShowAbilities();
        }

        private void DeselectUnit(Monster _unit)
        {
            // Remove from list
            selectedUnits.Remove(_unit);

            // Destroy selection sprite if exists
            if (selectionSprites.ContainsKey(_unit.unitId))
            {
                Destroy(selectionSprites[_unit.unitId].gameObject);
            }
        }

        public void DeselectAll()
        {
            if (selectionSprites.Count > 0)
            {
                foreach (GameObject sprite in selectionSprites.Values)
                {
                    Destroy(sprite.gameObject);
                }

                selectionSprites.Clear();
            }

            if (selectedUnits.Count > 0)
            {
                selectedUnits.Clear();
            }

            AbilityHandler.instance.ClearQueues();
            HideAbilities();
        }

        private void SelectAllLinemen()
        {
            List<Monster> linemen =
                GameMaster.instance.GetAllLinemenForPlayerSlot(
                    ConnectionManager.instance.MySlot
                );

            if (linemen.Count > 0)
            {
                foreach (Monster LM in linemen)
                {
                    SelectUnit(LM);
                }
            }
        }

        #endregion

        #region Hovering Helpers

        private void CreateHover(Monster _unit)
        {
            if (hoverSprites.ContainsKey(_unit.unitId))
            {
                return;
            }

            hoverSprites.Add(
                _unit.unitId,
                Instantiate(hoverSpritePrefab, _unit.transform)
            );
        }

        private void RemoveHover(int _unitId)
        {
            if (!hoverSprites.ContainsKey(_unitId))
            {
                return;
            }

            Destroy(hoverSprites[_unitId].gameObject);
        }

        private void ClearHovers()
        {
            if (hoverSprites.Count < 1)
            {
                return;
            }

            foreach (int _unitId in hoverSprites.Keys)
            {
                RemoveHover(_unitId);
            }

            hoverSprites.Clear();
        }

        #endregion

        #region Ability UI Helpers

        public void ShowAbilities()
        {
            abilityButtonUI.SetActive(true);
        }

        public void HideAbilities()
        {
            abilityButtonUI.SetActive(false);
        }

        #endregion
    }
}*/