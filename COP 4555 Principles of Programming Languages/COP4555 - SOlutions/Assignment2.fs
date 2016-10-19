(* QUESTION 3 ------------------------------------------------------------- *)
let rec transpose listList =            
    match listList with
    | [] -> failwith "Input Type Must Be: 'a list list."
    | [[]] -> [[]] 
    | headList::tailLists ->            //If non-empty list of lists
        match headList with             //Check one of the lists
        | [] -> []   
        | headItem::tailItems ->         //If more than one item in list
            let allHeads = List.map List.head listList              //Get all of the heads
            let allTails = transpose (List.map List.tail listList)  //Recursive call on tails
            allHeads::allTails;;        //Join head with tails
        
(* QUESTION 4 ------------------------------------------------------------- *)
(*

-----
1. Is there any circumstance in which a base case fails to return the correct 
result for the input?

    The base cases return to the correct input. If a list is of size zero 
    (e.g, an empty list) or of size 1, then it is already sorted.

-----
2. Is there any circumstance in which the code for a non-base case can fail to 
transform correct results returned by the recursive calls into the correct result 
for the input?

    The non-base case is incorrect as it only compares the first two elements of
    the list against each other. For example, say the input list was [5;4;1;2;3].
    The fist iteration of the non-base case will result in 4::sort(5::[1;2;3]), 
    which makes 4 the first element of the returning list, even if we assume
    the recursive call is correct. The non-base case only compares the first two 
    elements to each other and not the rest of the list.
    Therefore, 
        x1 :: sort (x2::xs)
        x2 :: sort (x1::xs)
    both fail to return correct results.

-----
3. Is there any circumstance in which the definition can make a recursive call on 
an input that is not smaller than the original input?

    All recursive calls are smaller, since the recursive calls are made using 
    x1::xs and x2::xs, which are smaller than x1::x2::xs.
*)

(* QUESTION 6 ------------------------------------------------------------- *)
let curry f a b = f(a, b);;
let uncurry f (a, b) = f a b;; 