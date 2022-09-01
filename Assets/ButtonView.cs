using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class ButtonView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


	private bool pointerDown;
	private float pointerDownTimer;
	[SerializeField]
	private float requiredHoldTime;

	public UnityEvent onLongClick;


    private void OnEnable()
    {
		onLongClick.AddListener(CheckHold);
    }

    private void OnDisable()
    {
		onLongClick.RemoveListener(CheckHold);
	}


    public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("OnPointerDown");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		Debug.Log("OnPointerUp");
	}

	private void Update()
	{
        if (pointerDown)
        {
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}
		}
		
	}

	private void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
	}

	public void CheckHold()
    {
        
    }

}

public enum ButtonState
{
	Normal,
	Gray,
	Found,
	Correct
}
