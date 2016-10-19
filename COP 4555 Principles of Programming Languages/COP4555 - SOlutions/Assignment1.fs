(*
Name: Aqib Shah
Panther ID: 3353447
COP4555-U01 - Principles of Programming Languages
Spring 2015
*)

(* Question 1 *)//----------------------------------------------

let rec gcd = function
| (a,0) -> a
| (a,b) -> gcd(b, a % b);;

///val gcd : int * int -> int

let (.+)(a,b)(c,d) = 
    let den = b*d
    let num = (a*d) + (c*b)
    let gdiv = gcd(num, den)
    (num/gdiv, den/gdiv);;

///val ( .+ ) : a:int * b:int -> c:'a * d:int -> int * int

let (.*)(a,b)(c,d) =
    let num = a*c
    let den = b*d
    let gdiv = gcd(num, den)
    (num/gdiv, den/gdiv);;

///val ( .* ) : a:int * b:int -> c:int * d:int -> int * int

(* Question 2 *)//----------------------------------------------
let revlists xs =
    List.map List.rev xs;;

///val revlists : xs:'a list list -> 'a list list

(* Question 3 *)//----------------------------------------------
let rec interleave (xs, ys) = 
    match (xs, ys) with 
    | (xs, []) -> xs
    | ([], ys) -> ys
     | (x::xs, y::ys) -> x::y::interleave(xs, ys);;

///val interleave : xs:'a list * ys:'a list -> 'a list

(* Question 4 *)//----------------------------------------------
let rec gencut (n, xs) = 
    match n with
    | 0 -> [],xs
    | n -> 
        let (lt, rt) = gencut(n-1, List.tail xs)
        (List.head xs::lt, rt);;

///val gencut : n:int * xs:'a list -> 'a list * 'a list

let cut xs = 
    let len = (List.length xs) / 2
    gencut(len, xs);;

///val cut : xs:'a list -> 'a list * 'a list

(* Question 5 *)//----------------------------------------------
let shuffle xs = 
    let (xs, ys) = cut xs
    interleave(xs, ys);;

///val shuffle : xs:'a list -> 'a list

(* Question 6 *)//----------------------------------------------
let rec countaux(deck, target) = 
    if deck = target then 0
    else countaux(shuffle(deck), target) + 1;;

///val countaux : deck:'a list * target:'a list -> int when 'a : equalit

let countshuffles n =
    let list = [1..n]
    let slist = shuffle list
    countaux( slist, list ) + 1;;

///val countshuffles : n:int -> int