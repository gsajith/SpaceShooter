using UnityEngine;
using System.Collections;

[System.Serializable]
public class MultidimensionalInt // taken from http://answers.unity3d.com/questions/64479/how-to-declare-a-multidimensional-array-of-strings.html
{
	public int[] intArray = new int[1];
	
	public int this[int index] {
		get {
			return intArray[index];
		}
		
		set {
			intArray[index] = value;
		}
	}
	
	public int Length {
		get {
			return intArray.Length;
		}
	}
	
	public long LongLength {
		get {
			return intArray.LongLength;
		}
	}
}

