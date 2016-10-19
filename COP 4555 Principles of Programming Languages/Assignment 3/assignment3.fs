(*

Assignment # 3
COP-4555 TTH 2:00-3:15 PM
Name: Hamilton Chevez
PID: 3350827
I hereby certify that this document is of my own work:


*)


(*Question 1*)
let rec inner ls1 ls2 =
  match ls1, ls2 with
  |[],[] -> 0
  |x::xs, y::ys -> x*y + inner xs ys;; // take the head of each sub vector and multiply them together and then add

printfn "The inner vector of [2;3;4;5][4;5;6;7] is: %o" (inner [2;3;4;5][4;5;6;7]);;
printfn "The inner vector of [1;2][4;55] is: %o" (inner [1;2][4;55]);;
printfn "The inner vector of [44;66;67][55;43;33] is: %o" (inner [44;66;67][55;43;33]);;


(*QUESTION 2*)
// my transpose function from the previous assignment
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
printfn "Matrix multiplication: \n [[1;2;3];[4;5;6]] * [[0;1];[3;2];[1;2]] = "
multiply([[1;2;3];[4;5;6]],[[0;1];[3;2];[1;2]]);;
printfn "Matrix multiplication: \n [[22;3];[16;56]] * [[0;1];[3;2]] = "
multiply([[22;3];[16;56]],[[0;1];[3;2]]);;
printfn "Matrix multiplication: \n [[1;2;3]] * [[0];[3];[1]] = "
multiply([[1;2;3]],[[0];[3];[1]]);;

(* Question 3
 Assuming xs is a list of the form [[1];[2];[3];...;[n]] then flatten1 will behave as follows:

   List.fold (@) [] [[1];[2];[3]; ...;[n]]
   List.fold (@) ((@) [] [1]) [[2];[3]; ...;[n]]
      Simplify ... List.fold (@) [1] [[2];[3]; ...;[n]]
   List.fold (@) (((@) [1] [2]) [[3]; ...;[n]]
      Simplify ... List.fold (@) [1;2] [[3]; ...;[n]]
   List.fold (@) (((@) [1;2] [3]) [[4]; ...;[n]]
      Simplify ... List.fold (@) [1;2;3] [[4]; ...;[n]]
  
   Hence, for flatten1 there will be n recursive calls. For every recursive call done on xs,
   the list on the left side of the append function grows larger by one. So, if each list was of size x,
   then the asymptotic complexity can be calculated as follows:

        0 + x + 2x + 3x + ... + (n-1)x          Note, the list grows by 1 each time
        = x * n * (n-1) / 2
        = O (x * n^2)
  
  For flatten2, if we let xs again equal [[1];[2];[3]; ...;[n]], then the calls are as follows:

  List.foldBack (@) [[1];[2];[3]; ...;[n]] []
  (@) [1] (List.foldBack (@) [[2];[3]; ...;[n]] [])
  (@) [1] ((@) [2] (List.foldBack (@) [[3]; ...;[n]] []))
  (@) [1] ((@) [2] ((@) [3](List.foldBack (@) [[4]; ...;[n]] [])))

  In the case of flatten2, if each list is the size of x, then the list on the left-side of the append is always
  equals to x. Hence, the asymptotic complexity can be calculated as follows:

  x + x + x +  ...  + x
  = O(x*n)

  Therefore, flatten2 is the more efficient implementation.
*)

//Question 4
(*
    twice successor 0 = 2 = 2^1
    twice twice successor 0 = 4 = 2^2
    twice twice twice successor 0 = 16 = 2^4
    twice twice twice twice successor 0 = 65536 = 2^16 
    ...

    Thefore, the current value is equal to 2 to the power of the previous value.

    n occurences of twice = 2^ (prev-value)  Therefore it cant defined recursively. 
    For example,
        f(n) = 
        If n = 0, then 1
        Else 2 ^ (f(n-1))

    In F#, this can be written as ...
        let rec f = function
            | 0 -> 1.0
            | n -> 2.0 ** (f (n-1));;
*)

(*
    Question 5
    ArmStrong Definition:
    A positive integer is an Armstrong number if it is equal to the sum of the cubes of its digits 
    – e.g., the first such number is 1 and the second is 153.
*)

// create a stream of ints
type 'a stream = Cons of 'a * (unit -> 'a stream);;

// Stream of integers - streams.fxs
let rec upfrom n = Cons (n, fun () -> upfrom (n+1));;

// remove the first n items from a list -streams.fsx
let rec drop n (Cons (x,xsf)) =
  match n with
    | 0 -> Cons (x,xsf)
    | _ -> drop (n-1) (xsf());;


// Select the first n itmes from an int stream - streams.fsx
let rec take n (Cons(x,xsf)) = 
  match n with
    | 0 -> []
    | _ -> x :: take (n-1) (xsf());;

// Pick up elements that satisfy a condition  - streams.fxs
let rec filter  p (Cons (x, xsf)) = 
  if p x then Cons (x, fun () -> filter p (xsf()))
  else filter p (xsf());;

// create an armstrong number from the head of the stream
let rec buildArmStrong = function
    | [] -> 0
    | x::xs -> (x*x*x) + buildArmStrong xs;;

// take an int split it by powers of ten
let rec delimitByTen = function
    | 0 -> []
    | x -> x % 10 :: delimitByTen (x / 10);;


// validating function to be used by the above filter functions
let isArmStrong n =
    if n > 409 then failwith "given definition, there does not exist an armstrong number beyond the 4th armstrong value"
    else n = buildArmStrong(delimitByTen n);;

// generate list of armstrongs
let armstrongs = filter (fun x -> isArmStrong x)(upfrom 2);;


let listArmStrongs = take 3 armstrongs;;
printfn "The second, third, and fourth armstrong numbers are %A" listArmStrongs;;