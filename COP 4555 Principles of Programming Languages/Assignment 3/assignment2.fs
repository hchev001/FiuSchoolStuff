//let rec inner lst1 lst2 = function
//| [], [] -> 0
//| x::xs, y::ys -> 
//  let t1 = x*(y:int)
//  let t2 = inner xs ys 
//  t1 + t2;;


(*Question 1*)
let rec inner ls1 ls2 =
  match ls1, ls2 with
  |[],[] -> 0
  |x::xs, y::ys -> x*y + inner xs ys;;

(*QUESTION 2*)
let rec transpose = function
| [] -> failwith "incorrect arg type. Can't transpose"
|[[]] -> [[]]
|x::xs ->
  match x with
  | [] -> []
  | y::ys ->
    let heads = List.map List.head (x::xs)
    let tails = transpose (List.map List.tail (x::xs))
    heads::tails;;

(* maps every column of ys that has been transposed already  to the head of xs and gets inner product. Repeats for the rest of the rows existing in xs*)
let rec muxHelp = function
|[],_ -> []
|_,[] -> []
|x::xs, ys -> List.map( fun col -> inner x col) ys :: muxHelp(xs, ys);;

(* multiply xs and transpose ys*)
let multiply (xs, ys) = muxHelp(xs, transpose(ys));;

multiply([[1;2;3];[4;5;6]],[[0;1];[3;2];[1;2]]);;

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