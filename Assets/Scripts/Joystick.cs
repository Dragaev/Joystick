using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBG;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x/2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (inputVector.x != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}

