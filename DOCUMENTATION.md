<!-- whhy are comments like this this sucks -->

anyways

___

what the hell is that thang up ther ^

==WHY AM I YELLOW !? !? !? !? ! ?!? !? !?? :interrobang:==

```c#
Console.WriteLine("Hlelo worlb");
// that code says hello world in the console. awesome !

Console.WriteLine("im gonna getcha! im gonna getcha! >:D");
// hey woah waoh waoh waoh woah slow down there bsuter
```
| table arc | table arc
| :-- | --: |
| an item | another item |
| yeagh u can just go forever bay bee | hellyeagh :hammer_and_pick:|




 # Table of Contents
 - [Vector2 Class](#vector-2)
 - [Vector3 Class](#vector-3)
 - [Vector4 Class](#vector-4)
 - [Matrix3 Class](#matrix-3)
 - [Matrix4 Class](#matrix-4)
 ---

 # Vector2 {#vector-2}

 ## Constructor
 |                Name               |                 Description                 |
|:---------------------------------:|:-------------------------------------------:|
| Vector2(float x = 0, float y = 0) | Creates a Vector2 with the specified values. |

 ## Properties
 | Name       |                                  Description |
|:-----------|---------------------------------------------|
| Magnitude  | Returns the magnitude of the vector.         |
| Normalized | Returns the vector as if it were normalized. |

## Functions
| Name                             |                                                                   Description |
|----------------------------------|------------------------------------------------------------------------------|
| Normalize()                      | Makes the vector normalized, then returns the vector.                         |
| ToString()                       | Returns the vector converted to a string.                                     |
| DotProduct(Vector2 other)        | Returns the dot product of the current vector and one other vector.           |
| DotProduct(Vector2 a, Vector2 b) | Returns the dot product of two vectors.                                       |
| Distance(Vector2 other)          | Returns the distance between the current point and one other point as a float.|
| Distance(Vector2 a, Vector2 b)   | Returns the distance between two different points as a float.                 |
| Angle(Vector2 other)             | Returns the angle between the current vector and one other vector in radians. |
| Angle(Vector2 a, Vector2 b)      | Returns the angle between two different vectors in radians.                   |

## Operators
| Name                            |                                           Description     |
|---------------------------------|-----------------------------------------------------------|
| ==(Vector2 left, Vector2 right) | Returns true if both of the vectors' axes are equal.      |
| !=(Vector2 left, Vector2 right) | Returns false if both of the vectors' axes are equal.     |
| +(Vector2 left, Vector2 right)  | Adds two vectors together.                                |
| -(Vector2 left, Vector2 right)  | Subtracts the first vector by the second.                 |
| *(Vector2 left, float scalar)   | Scales the vector by the scalar.                          |
| *(float scalar, Vector2 right)  | Scales the vector by the scalar.                          |
| /(Vector2 left, float scalar)   | Divides the vector by the scalar. Will not divide by zero.|

## Conversions
|                   Name                  |                                 Description                                 |
|:---------------------------------------:|:---------------------------------------------------------------------------:|
| Vector2(System.Numerics.Vector2 vector) | Implicit conversion from System.Numeric's Vector2 to MathLibrary's Vector2. |
| System.Numerics.Vector2(Vector2 vector) | Implicit conversion from MathLibrary's Vector2 to System.Numeric's Vector2  |

---

 # Vector3 {#vector-3}

 ## Constructor
 |                Name               |                 Description                 |
|:---------------------------------:|:-------------------------------------------:|
| Vector3(float x = 0, float y = 0, float z = 0) | Creates a Vector3 with the specified values. |

 ## Properties
| Name       |                                  Description |
|:-----------|---------------------------------------------|
| Magnitude  | Returns the magnitude of the vector.         |
| Normalized | Returns the vector as if it were normalized. |

## Functions
| Name                               | Description                                                                    |
|------------------------------------|--------------------------------------------------------------------------------|
| Normalize()                        | Makes the vector normalized, then returns the vector.                          |
| ToString()                         | Returns the vector converted to a string.                                      |
| CrossProduct(Vector3 other)        | Returns the cross product of the current vector and one other vector.          |
| CrossProduct(Vector3 a, Vector3 b) | Returns the cross product of two different vectors.                            |
| DotProduct(Vector3 other)          | Returns the dot product of the current vector and one other vector.            |
| DotProduct(Vector3 a, Vector3 b)   | Returns the dot product of two vectors.                                        |
| Distance(Vector3 other)            | Returns the distance between the current point and one other point as a float. |
| Distance(Vector3 a, Vector3 b)     | Returns the distance between two different points as a float.                  |
| Angle(Vector3 other)               | Returns the angle between the current vector and one other vector in radians.  |
| Angle(Vector3 a, Vector3 b)        | Returns the angle between two different vectors in radians.                    |

## Operators
| Name                            |                                           Description     |
|---------------------------------|-----------------------------------------------------------|
| ==(Vector3 left, Vector3 right) | Returns true if both of the vectors' axes are equal.      |
| !=(Vector3 left, Vector3 right) | Returns false if both of the vectors' axes are equal.     |
| +(Vector3 left, Vector3 right)  | Adds two vectors together.                                |
| -(Vector3 left, Vector3 right)  | Subtracts the first vector by the second.                 |
| *(Vector3 left, float scalar)   | Scales the vector by the scalar.                          |
| *(float scalar, Vector3 right)  | Scales the vector by the scalar.                          |
| /(Vector3 left, float scalar)   | Divides the vector by the scalar. Will not divide by zero.|

## Conversions
|                   Name                  |                                 Description                                 |
|:---------------------------------------:|:---------------------------------------------------------------------------:|
| Vector3(System.Numerics.Vector3 vector) | Implicit conversion from System.Numeric's Vector3 to MathLibrary's Vector3. |
| System.Numerics.Vector3(Vector3 vector) | Implicit conversion from MathLibrary's Vector3 to System.Numeric's Vector3  |

 (table of functions) 

 ---

 # Vector4 {#vector-4}

 ## Constructor
  |                Name               |                 Description                                          |
|:---------------------------------:|:----------------------------------------------------------------------:|
| Vector4(float x = 0, float y = 0, float z = 0, float w = 0) | Creates a Vector4 with the specified values. |

## Properties
| Name       |                                  Description |
|:-----------|---------------------------------------------|
| Magnitude  | Returns the magnitude of the vector.         |
| Normalized | Returns the vector as if it were normalized. |

## Functions
| Name                               | Description                                                                    |
|------------------------------------|--------------------------------------------------------------------------------|
| Normalize()                        | Makes the vector normalized, then returns the vector.                          |
| ToString()                         | Returns the vector converted to a string.                                      |
| CrossProduct(Vector4 other)        | Returns the cross product of the current vector and one other vector, ignoring the w axis.          |
| CrossProduct(Vector4 a, Vector4 b) | Returns the cross product of two different vectors, ignoring the w axis.                           |
| DotProduct(Vector4 other)          | Returns the dot product of the current vector and one other vector.            |
| DotProduct(Vector4 a, Vector4 b)   | Returns the dot product of two vectors.                                        |
| Distance(Vector4 other)            | Returns the distance between the current point and one other point as a float. |
| Distance(Vector4 a, Vector4 b)     | Returns the distance between two different points as a float.                  |
| Angle(Vector4 other)               | Returns the angle between the current vector and one other vector in radians.  |
| Angle(Vector4 a, Vector4 b)        | Returns the angle between two different vectors in radians.                    |

## Operators
| Name                            |                                           Description     |
|---------------------------------|-----------------------------------------------------------|
| ==(Vector4 left, Vector4 right) | Returns true if both of the vectors' axes are equal.      |
| !=(Vector4 left, Vector4 right) | Returns false if both of the vectors' axes are equal.     |
| +(Vector4 left, Vector4 right)  | Adds two vectors together.                                |
| -(Vector4 left, Vector4 right)  | Subtracts the first vector by the second.                 |
| *(Vector4 left, float scalar)   | Scales the vector by the scalar.                          |
| *(float scalar, Vector4 right)  | Scales the vector by the scalar.                          |
| /(Vector4 left, float scalar)   | Divides the vector by the scalar. Will not divide by zero.|

## Conversions
|                   Name                  |                                 Description                                 |
|:---------------------------------------:|:---------------------------------------------------------------------------:|
| Vector4(System.Numerics.Vector4 vector) | Implicit conversion from System.Numeric's Vector4 to MathLibrary's Vector4. |
| System.Numerics.Vector4(Vector4 vector) | Implicit conversion from MathLibrary's Vector4 to System.Numeric's Vector4  |

 (table of functions)

 # Matrix3 {#matrix-3}

 ## Constructor
 | Name                                                                                                                 | Description                                  |
|----------------------------------------------------------------------------------------------------------------------|----------------------------------------------|
| Matrix3(<br>float m00, float m01, float m02,<br>float m10, float m11, float m12,<br>float m20, float m21, float m22) | Creates a Matrix3 with the specified values. |

 ## Properties

 ## Functions

 ## Operators

 (table of functions)[^1]

 # Matrix4 {#matrix-4}

 (table of functions)

 [^1]: look at how i did the multiplication code for the matrices im so cool
    ```c#
                public static Matrix3 operator *(Matrix3 a, Matrix3 b)
                {
                    Matrix3 result = new Matrix3();
            
                    for (int i = 0; i < 9; i++)
                    {
                        byte row = (byte)(i / 3);
                        byte column = (byte)(i % 3);

                        result[i] =
                            (a[row * 3] * b[column]) +
                            (a[(row * 3) + 1] * b[column + 3]) +
                            (a[(row * 3) + 2] * b[column + 6]);
                    }

                    return result;
                }
    ```
