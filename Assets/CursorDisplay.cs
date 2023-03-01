using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CursorDisplay : MonoBehaviour
{
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [SerializeField] private Sprite defaultCursor;
    [SerializeField] private Sprite interactableCursor;

    private CurrentCursor currentCursor;

    [SerializeField] private Transform playerLocation;

    private GameObject mouseCursor;
    private Image mouseImage;
    private RectTransform mouseTransform;
    private RectTransform renderTransform;

    private Vector2 defaultOffset = new Vector2(32, -32);
    private Vector2 interactableoffset = new Vector2(0, 0);

    [SerializeField]
    private float maxInteractionDistance = 1.5f;

    private enum CurrentCursor
    {
        defaultCursor,
        interactable
    }
    void Start()
    {
        Cursor.visible = false;
        CreateMouse();
        SetDefaultCursor();
    }

    private void SetDefaultCursor()
    {
        // Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
        Cursor.visible = false;
        mouseImage.sprite = defaultCursor;
        mouseImage.color = new Color(1, 1, 1, 1);
        renderTransform.localPosition = defaultOffset;
        currentCursor = CurrentCursor.defaultCursor;
    }

    private void CreateMouse()
    {
        mouseCursor = new GameObject("Cursor");
        mouseCursor.transform.SetParent(this.transform);
        mouseTransform = mouseCursor.AddComponent<RectTransform>();

        var mouseContainer = new GameObject("Container");
        mouseContainer.transform.SetParent(mouseCursor.transform);
        
        renderTransform = mouseContainer.AddComponent<RectTransform>();
        renderTransform.sizeDelta = new Vector2(64, 64);

        mouseImage = mouseContainer.AddComponent<Image>();
        mouseImage.raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Cursor.visible = false;
        
        mouseTransform.position = Input.mousePosition;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (!hit)
        {
            if (currentCursor != CurrentCursor.defaultCursor) 
                SetDefaultCursor();
            
            return;
        }

        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable") && currentCursor != CurrentCursor.interactable)
            SetInteractableCursor();

        if (Vector2.Distance(playerLocation.position, hit.collider.gameObject.transform.position) > maxInteractionDistance)
        {
            mouseImage.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            mouseImage.color = new Color(1, 1, 1, 1);
        }
    }

    private void SetInteractableCursor()
    {
        // Cursor.SetCursor(interactableCursor, hotSpot, cursorMode);
        Cursor.visible = false;
        mouseImage.sprite = interactableCursor;
        renderTransform.localPosition = interactableoffset;
        currentCursor = CurrentCursor.interactable;
    }
}
