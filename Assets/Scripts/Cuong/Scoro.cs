using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoro : MonoBehaviour
{
    public bool Value;
    public int NumTuret = 0;
    public void setValue(bool value)
    {
        this.Value = value;
    }

	public void setNum(int num)
	{
		this.NumTuret = NumTuret + num;
	}
	
}
