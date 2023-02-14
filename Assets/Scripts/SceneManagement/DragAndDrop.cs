using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour,IDragHandler,IEndDragHandler
{
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPosition;
    private PlayerStatus playerStatus;
    [SerializeField] private int cost;
    private Vector3 spawnArea;
    private void Awake() 
    {
        draggingObjectRectTransform = transform as RectTransform;
        playerStatus = GameObject.FindObjectOfType<PlayerStatus>();
    }
    private void Start() 
    {
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform,eventData.position,eventData
        .pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = globalMousePosition;
            spawnArea = globalMousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingObjectRectTransform.position = startPosition;
        playerStatus.ChosenCard(gameObject,spawnArea);
    }
}
