//Name: Aqib Shah
//PantherID # 3353447
//Homework 3

//Ques. # 1

let rec inner xs ys =
    match (xs, ys) with 
    | ([],  ys) -> 0
    | (xs,  []) -> 0    //Not neccessary, but avoids 'Incomplete pattern matches...'
    | (x::xs,   y::ys) -> (x*y) + inner xs ys;;


//Ques. # 2
let rec transpose = function 
    | []::xs -> []
    | xs -> List.map List.head xs:: transpose (List.map List.tail xs);;

let rec multiply (xs, ys) =
    match (xs, ys) with
    | ([], ys) -> []
    | (xs, []) -> []
    | (xs, ys) -> List.map (fun z -> inner (List.head xs) z) (transpose ys) :: multiply (List.tail xs, ys);;

//Ques. # 3
(* Assuming xs equals [[1];[2];[3]; ...;[n]], then flatten1 is called as follows:
    
    List.fold (@) [] [[1];[2];[3]; ...;[n]]
    List.fold (@) ((@) [] [1]) [[2];[3]; ...;[n]]
        Simplify ... List.fold (@) [1] [[2];[3]; ...;[n]]
    List.fold (@) (((@) [1] [2]) [[3]; ...;[n]]
        Simplify ... List.fold (@) [1;2] [[3]; ...;[n]]
    List.fold (@) (((@) [1;2] [3]) [[4]; ...;[n]]
        Simplify ... List.fold (@) [1;2;3] [[4]; ...;[n]]
    ...

    So, it is clear to see that there will be n recursive calls. On each recursive call
    the list on the left-side of the append function grows larger by one. So, if each
    list was of size x, then  the asymptotic complexity can be calculated as follows:
        
        0 + x + 2x + 3x + ... + (n-1)x          Note, the list grows by 1 each time
        = x * n * (n-1) / 2
        = O (x * n^2)

    As for flatten2, if xs equals [[1];[2];[3]; ...;[n]], then the calls are:
    
    List.foldBack (@) [[1];[2];[3]; ...;[n]] []
    (@) [1] (List.foldBack (@) [[2];[3]; ...;[n]] [])
    (@) [1] ((@) [2] (List.foldBack (@) [[3]; ...;[n]] []))
    (@) [1] ((@) [2] ((@) [3](List.foldBack (@) [[4]; ...;[n]] [])))

    In this case, the if each list was of size x, then the list on the left-side of the
    append is always equal to x. Therefore, the asymptotic complexity can be calculated
    as follows:

        x + x + x + ... + x
        = O (x * n)

    Hence, flatten2 is more efficient. 
*)

//Ques. # 4
(*
    twice successor 0 = 2 = 2^1
    twice twice successor 0 = 4 = 2^2
    twice twice twice successor 0 = 16 = 2^4
    twice twice twice twice successor 0 = 65536 = 2^16 
    ...

    Thefore, the current value is equal to 2 to the power of the previous value.

    n occurences of twice = 2^ (prev-value)

    So, it must defined recursively. For example,

    f(n) = 
    If n = 0, then 1
    Else 2 ^ (f(n-1))

    In F#, this can be written as ...
    let rec f = function
        | 0 -> 1.0
        | n -> 2.0 ** (f (n-1));;
*)

//Ques. # 5 
type 'a stream = Cons of 'a * (unit -> 'a stream);;

let rec map f (Cons(x, xsf)) = Cons (f x, fun() -> map f (xsf()));;
         
//Ques. # 6
type Exp = 
    Num of int
    | Neg of Exp
    | Sum of Exp * Exp
    | Diff of Exp * Exp
    | Prod of Exp * Exp
    | Quot of Exp * Exp;;

type 'a option = None | Some of 'a;;

let rec evaluate = function
    | Num n -> Some n
    | Neg e -> 
                match evaluate e with
                | None -> None
                | Some e -> Some -e
    | Sum (x, y) -> 
                match (evaluate x, evaluate y) with
                | (None, _) -> None
                | (_, None) -> None
                | (Some x, Some y) -> Some (x + y)
    | Diff (x, y) -> 
                match (evaluate x, evaluate y) with
                | (None, _) -> None
                | (_, None) -> None
                | (Some x, Some y) -> Some (x - y)
    | Prod (x, y) -> 
                match (evaluate x, evaluate y) with
                | (None, _) -> None
                | (_, None) -> None
                | (Some x, Some y) -> Some (x * y)
    | Quot (x, y) -> 
                match (evaluate x, evaluate y) with
                | (None, _) -> None
                | (_, None) -> None
                | (_, Some 0) -> None
                | (Some x, Some y) -> Some (x / y);; 