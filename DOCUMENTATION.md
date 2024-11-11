<!-- whhy are comments like this this sucks -->

anyways

___

what the hell is that thang up ther ^

==WHY AM I YELLOW !? !? !? !? ! ?!? !? !?? :interrobang:==

```c#
Console.WriteLine("Hlelo worlb");
// that code says hello world in the console. awesome !

Console.WriteLine("im gonna getcha! im gonna getcha! >:D")
// hey woah waoh waoh waoh woah slow down there bsuter
```
| table arc | table arc
| :-- | --: |
| an item | another item |
| yeagh u can just go forever bay bee | hellyeagh :hammer_and_pick:|

 
 ## Table of Contents

 (insert table that links to every single class here)

 ## Vector2

 (table of functions)

 ## Vector3

 (table of functions)

 ## Vector4

 (table of functions)

 ## Matrix3

 (table of functions)

 ## Matrix4

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
