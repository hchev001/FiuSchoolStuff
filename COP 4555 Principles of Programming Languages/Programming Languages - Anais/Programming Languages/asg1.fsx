(* Anais Hernandez
   PID: 3884585
   COP 4555 U01- Homework 1 
*)


(* ****Problem 1**** *)
(*Finds the greatest common divisor*)
let rec gcd = function
  | (a,0) -> a
  | (a,b) -> gcd (b, a % b);;

(*Adds two fractions*)
let (.+) (a,b) (c,d) = 
    let denom = b*d
    let top = ((denom/b) * a) + ((denom/d) * c)
    let div = gcd(top, denom)
    (top/div, denom/div);;

(*Multiplies two fractions*)
let (.*) (a,b) (c,d) = 
    let div = gcd(a*c, b*d)
    ((a*c)/div, (b*d)/div);;



((* ****Problem 2**** *)
(* Reverses all sublists *)
let revlists alist = List.map List.rev alist;;



(* ****Problem 3**** *)
(* Interleaves two lists *)
let rec interleave = function
    | ([], ys) -> ys
    | (xs, []) -> xs
    | (xs, ys) -> List.head xs::List.head ys::interleave(List.tail xs, List.tail ys);;



(* ****Problem 4**** *)
(* Cuts a list into two parts where n specfies the size of the first list *)
let rec gencut (n, xs) =
    if n=0 then ([], xs)
    else let (left, right) = gencut(n-1, List.tail xs)
         (List.head xs::left, right);;

(* Cuts a list in half by calling gencut to cut it by half the length of the list *)
let cut xs = gencut(List.length xs/2, xs);;


(* ****Problem 5**** *)
(* *)
let shuffle xs = interleave(gencut(List.length xs/2, xs));;


(* ****Problem 6**** *)
let rec countaux(deck,target) = 
    if deck=target then 0
    else countaux(shuffle(deck), target) + 1;;

let countshuffles(n) = 
    let alist = [1..n]
    let blist = shuffle alist
    countaux(blist, alist)+1;;