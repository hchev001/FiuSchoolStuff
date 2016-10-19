(* Anais Hernandez
   PID: 3884585
   COP 4555
   HW #3 
*)


(* --- QUESTION 1 --- *)
(* Curried function that takes two vectors as input (2 int list) and outputs their inner product *)
  
let rec inner xs ys =
  	match (xs,ys) with
      |[],[] -> 0
      |x::xs,y::ys -> (x*y) + inner xs ys;;



(* --- QUESTION 2 --- *)
(* Uncurried function that performs matrix multiplication *)

let rec transpose = function
    |[] -> failwith "cannot be transposed"
    |[]::xs -> []
    |xs -> List.map List.head xs :: transpose(List.map List.tail xs);;

(*Map every column of ys to head of xs and get inner product. Do same for rest of rows in xs*)
let rec multihelp = function
    |[],_ -> []
    |_,[] -> []
    |x::xs,ys -> List.map (fun column -> inner x column) ys :: multihelp (xs,ys);;

(* Multiply xs and transpose of ys *)
let multiply (xs, ys) = multihelp(xs, transpose(ys));;




(* --- QUESTION 3 --- *)
let rec fold f a = function
    | []    -> a
    | x::xs -> fold f (f a x) xs;;

let rec foldBack f xs a =
    match xs with
    | []    -> a
    | y::ys -> f y (foldBack f ys a);;

let flatten1 xs = List.fold (@) [] xs;;
let flatten2 xs = List.foldBack (@) xs [];;

(*

Asymptotic Time Complexity:
FLATTEN1
For a list of length n, flatten1 calls the fold function n+1 times.
The fold function applies the function @ each time it is called, making the list to append larger, so it takes O(N).
Therefore, flatten1 has a time complexity of O(N) * O(N) = O(N^2).

FLATTEN2
For a list of length n, flatten2 calls the foldback function n+1 times, as well.
However, the foldback function doesn't apply the function @ each time. If each list in xs is of size x, in this case each list is of length 1, so it appends between n lists of length 1, which is O(1).
Therefore, flatten2 has a time complexity of O(N) * O(1) = O(N). 


Experiment:
let list = List.map (fun x ->[x]) [1..100];;
flatten1 -> 0 seconds
flatten2 -> 0 seconds

let list = List.map (fun x ->[x]) [1..1000];;
flatten1 -> .013 seconds
flatten2 -> 0 seconds

let list = List.map (fun x ->[x]) [1..10000];;
flatten1 -> 1.263 seconds
flatten2 -> .001 seconds

By experimenting, flatten1 performs slower than flatten2 for list of 100, 1000, and 10000, and therefore, has a greater time complexity.
*)



(* --- QUESTION 4 --- *)
(*
twice successor 0 =                       2 		= 	2^1     = 2^1
twice twice successor 0 = 				        4		  =		2^2     = 2^2
twice twice twice successor 0 = 	       16		  =		2^4     = 2^(2^2)
twice twice twice twice successor 0 =    65536	=		2^16    = 2^(2^(2^2))
twice twice twice twice twice successor 0       =   2^65536 = 2^(2^(2^(2^2)))

Therefore, for n occurreces of twice, the value it returns is 2^2^..^2, where the number of 2's is n.
For n>4, the result is already a very large number. 
*)



(* --- QUESTION 5 --- *)
type 'a stream = Cons of 'a * (unit -> 'a stream)

(* Map function to each element in stream *)
let rec map f (Cons (x, xsf)) =
    Cons(f x, fun () -> map f (xsf()));;




(* --- QUESTION 6 --- *)
type Exp =
    Num of int
  | Neg of Exp
  | Sum of Exp * Exp
  | Diff of Exp * Exp
  | Prod of Exp * Exp
  | Quot of Exp * Exp

type 'a option = None | Some of 'a

let rec evaluate = function
    | Num n -> Some n
    | Neg e -> match evaluate e with
               | Some n -> Some (-n)
               | _ -> None
    |Sum (a, b) -> match (evaluate a, evaluate b) with
                   | Some x, Some y -> Some (x + y)
                   | _ -> None
    |Diff (a, b) -> match (evaluate a, evaluate b) with
                    | Some x, Some y -> Some (x - y)
                    | _ -> None
    |Prod (a, b) -> match (evaluate a, evaluate b) with
                    | Some x, Some y -> Some (x * y)
                    | _ -> None
    |Quot (a, b) -> match (evaluate a, evaluate b) with
                    | Some x, Some 0 -> None
                    | Some x, Some y -> Some (x / y);;

