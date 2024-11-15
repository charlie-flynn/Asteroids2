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

 
 ## Table of Contents

 - [Vector2 Class](#vector-2)
 - [Vector3 Class](#vector-3)
 - [Vector4 Class](#vector-4)
 - [Matrix3 Class](#matrix-3)
 - [Matrix4 Class](#matrix-4)

 ## Vector2 {#vector-2}

 ### Constructor
 |                Name               |                 Description                 |
|:---------------------------------:|:-------------------------------------------:|
| Vector2(float x = 0, float y = 0) | Creates a vector with the specified values. |

 ### Properties
 | Name       |                                  Description |
|:-----------|---------------------------------------------|
| Magnitude  | Returns the magnitude of the vector.         |
| Normalized | Returns the vector as if it were normalized. |

### Functions
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

### Operators
| Name                            |                                           Description |
|---------------------------------|------------------------------------------------------|
| ==(Vector2 left, Vector2 right) | Returns true if both of the vectors' axes are equal.  |
| !=(Vector2 left, Vector2 right) | Returns false if both of the vectors' axes are equal. |
| +(Vector2 left, Vector2 right)  | Adds two vectors together.                            |
| -(Vector2 left, Vector2 right)  | Subtracts the first vector by the second.             |
| *(Vector2 left, float scalar)   | Scales the vector by the scalar.                      |
| *(float scalar, Vector2 right)  | Scales the vector by the scalar.                      |
| /(Vector2 left, float scalar)   | Divides the vector by the scalar.                     |

### Conversions
|                   Name                  |                                 Description                                 |
|:---------------------------------------:|:---------------------------------------------------------------------------:|
| Vector2(System.Numerics.Vector2 vector) | Implicit conversion from System.Numeric's Vector2 to MathLibrary's Vector2. |
| System.Numerics.Vector2(Vector2 vector) | Implicit conversion from MathLibrary's Vector2 to System.Numeric's Vector2  |

 ## Vector3 {#vector-3}

 (table of functions)

 ## Vector4 {#vector-4}

 (table of functions)

 ## Matrix3 {#matrix-3}

 (table of functions)

 ## Matrix4 {#matrix-4}

 (table of functions)

 ### look at how i did the multiplication code for the matrices im so cool

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
