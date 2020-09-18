using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZCard;

public class FUNCTION : MonoBehaviour
{
    public static Vector2 GetMousePosition(){
    	Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	return MousePosition;
    }

    public static bool Right(){
		if(PlayerHandUtils.CARD_MODE)
		{
			return (0 == PlayerHandUtils.CARD_ACTION || 2 == PlayerHandUtils.CARD_ACTION);
		}
    	if(Input.GetKeyDown(KeyCode.D)||Input.GetKey(KeyCode.D)){
    		return true;
    	}else{
    		return false;
    	}
    }
    public static bool Left(){
		if(PlayerHandUtils.CARD_MODE)
		{
			return false;
		}
    	if(Input.GetKeyDown(KeyCode.A)||Input.GetKey(KeyCode.A)){
    		return true;
    	}else{
    		return false;
    	}
    }
    public static bool Jump(){
		if(PlayerHandUtils.CARD_MODE)
		{
			return (2 == PlayerHandUtils.CARD_ACTION);
		}
    	if(Input.GetKeyDown(KeyCode.Space)||Input.GetKey(KeyCode.Space)){
    		return true;
    	}else{
    		return false;
    	}
    }

	public static bool Dum() {
		if(PlayerHandUtils.CARD_MODE)
		{
			return (1 == PlayerHandUtils.CARD_ACTION);
		}
		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftCommand)){
    		return true;
    	}else{
    		return false;
    	}
	}
}
