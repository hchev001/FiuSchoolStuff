1.

let rec cartesian = function
    |([], []) -> []
    |(_,[]) -> []
    |([],_) -> []
    |(x::xs, y::ys) -> (x,y)::cartesian([x],ys)@cartesian(xs,[y])@cartesian(xs,ys);;


let rec cartesian = function
    |([], []) -> []
    |(x,[]) -> []
    |([],y) -> []
    |(x::xs, ys) -> (List.map (fun y -> x,y) ys)@(cartesian(xs, ys));;
                ///map current head (x) from xs to each y in list ys and append

2.

let rec powerset = function 
    | [] -> [[]] 
    | [x]::xs -> let a = powerset xs
                 a @ List.map(fun n -> x::n) a


5. 
Check 1: Base Case is correct. An empty list is already sorted. Although, there should be another base case for a list with length one, since that list is also sorted. i.e: ([x] -> [x])

Check 2: Non-base case is correct. L recursively gets split into M and N and the recursive calls will sort them correctly. The split lists are merged and it gives the correctly sorted L. 

Check 3: Recursive call is calling on a smaller input until it reaches a list of 1. L is split into M and N and then M is called to mergesort and split even further making the list shorter each time mergesort is called, same goes for N. However, when the list gets to length of 1, split L produces M = L N=[], therefore mergesort gets called again to sort list L.

Type: val mergesort : _arg1:'a list -> 'b list when 'b : comparison

The bug can be fixed by adding another base case to treat a list with length of 1. Below is the corrected mergesort:

  let rec mergesort = function
  | []  -> []
  | [x] -> [x]
  | L   -> let (M, N) = split L
           merge (mergesort M, mergesort N)







let rec powerset = function
    | [] -> [[]]
    | x::y::xs -> (List.map (fun a -> [x;y]) xs)@powerset(xs);;           

let rec powerset = function
    | [] -> [[]]
    | (x::xs) -> let a = powerset xs 
                 List.map (fun n -> x::n) a @ a

    [x;y]::powerset(xs);;

     > powerset [1;2;3];;
  val it : int list list
  = [[]; [3]; [2]; [2; 3]; [1]; [1; 3]; [1; 2]; [1; 2; 3]]




let rec transpose = function
    |[[]] -> [[]]
    |[_;[]] -> [[]]
    |[x::xs;y::ys] -> [x;y]::transpose [xs;ys];;

transpose [[1;2;3];[4;5;6]];;
  val it : int list list = [[1; 4]; [2; 5]; [3; 6]]

let rec transpose = function
    |[]::xs -> []
    |xs -> List.map List.head xs::transpose(List.map List.tail xs);;

  let rec interleave = function
    | ([], ys) -> ys
    | (xs, []) -> xs
    | (xs, ys) -> List.head xs::List.head ys::interleave(List.tail xs, List.tail ys);;
