# ChargeTheMost
This was a problem I was assigned during a recent interview with a big tech firm.
The problem is given a List of Tuple values (1,1)(2,2)(3,4)(4,5)(5,6)(6,7)(7,9)(8,10)(9,12).  Where the first number is the length of wire and the second number is the price.  Wrtie code for a method named, highestPrice, that accepts the Tuple List and the length as parameters and returns the highest price possible.

The first thing I noticed is that the table included values that could mess with the results.  For instance, the 6 costs 7 entry, is kindof not wanted because two 3 unit wires at 4 each would equal 6 and give a higher cost of 8.  So, I first went about solving for how to remove items from the table and ended up with the final solution in a recursive manner.

An important factor became obvious that you want the highest unit price sorted to the top of the list.  This is easy to figure out with cost divided by length.
Basically divide the length by the length of the highest unit price, where the length is less than the length of the input and then do the same to the remainder till we hit a number in the table or 0.

