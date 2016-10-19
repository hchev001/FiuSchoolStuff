//Context Free Grammar
//e := x | n | true | false | succ | pred | iszero | if e then e else e | e e | fun x -> e | rec x -> e | (e)

// Skeleton file for PCF interpreter

// This sets F# to read from whatever directory contains this source file.
System.Environment.set_CurrentDirectory __SOURCE_DIRECTORY__;;

//Defining tyes
(*
type term =
| ID of string | NUM of int | BOOL of bool | SUCC | PRED | ISZERO
| IF of term * term * term | APP of term * term
| FUN of string * term | REC of sting * term | ERROR of string
*)

#load "parser.fsx"

// This lets us refer to "Parser.Parse.parsefile" simply as "parsefile",
// and to constructors like "Parser.Parse.APP" simply as "APP".
open Parser.Parse

//SAMPLE I/O parsestr
//parsestr "iszero (succ 7)";;
//val it : term = APP (ISZERO,APP (SUCC,NUM 7))
//parsestr "((fun x -> succ x)(pred x))";;
//val it : term = APP (FUN ("x",APP (SUCC,ID "x")),APP (PRED,ID "x"))

let rec subst e x t =
    match e with
    | ID n -> if n = x then t else ID n
    | NUM n -> NUM n
    | BOOL b -> BOOL b
    | SUCC -> SUCC
    | PRED -> PRED
    | ISZERO -> ISZERO
    | IF (b, e1, e2) -> IF (subst b x t, subst e1 x t, subst e2 x t)
    | APP (e1, e2) -> APP (subst e1 x t, subst e2 x t)
    | FUN (s, e1) -> if x = s then FUN (s, e1) else FUN (s, subst e1 x t)
    | REC (s, e1) -> if x = s then REC (s, e1) else REC (s, subst e1 x t)
    | _ -> ERROR (sprintf "substitution error") 

//SAMPLE I/O subst
//subst (APP (ISZERO,APP (SUCC, ID "x"))) "x" (NUM 7);;
//val it : term = APP (ISZERO,APP (SUCC,NUM 7))
//subst (APP(SUCC, ID "x")) "x" (NUM 1);;
//val it : term = APP (SUCC,NUM 1)
//subst (APP (FUN ("x",APP (SUCC,ID "x")),APP (PRED,ID "x"))) "x" (NUM 3);;
//val it : term = APP (FUN ("x",APP (SUCC,ID "x")),APP (PRED,NUM 3))

// Here I show you a little bit of the implementation of interp. Note how ERRORs
// are propagated, how rule (6) is implemented, and how stuck evaluations
// are reported using F#'s sprintf function to create good error messages.
let rec interp = function
| ERROR s -> ERROR s
| NUM n -> NUM n    // Rule (1)
| BOOL b -> BOOL b  // Rule (2)
| SUCC -> SUCC      // Rule (3)
| PRED -> PRED      // Rule (3)
| ISZERO -> ISZERO  // Rule (3)
| ID s -> ID s
| FUN (x, e) -> FUN (x, e)  // Rule (9)
| REC (x, e) -> REC (x, e)  // Rule (11)
| IF (b,e1,e2) -> 
    match (interp b,e1,e2) with
    | (ERROR s, _, _) -> ERROR s          // ERRORs are propagated
    | (_, ERROR s, _) -> ERROR s
    | (_, _, ERROR s) -> ERROR s
    | (BOOL true, e1, e2) -> interp e1    // Rule (4)
    | (BOOL false, e1, e2) -> interp e2   // Rule (5)
    | (v, e1, e2) -> ERROR (sprintf "'if' needs boolean argument, not '%A'" v)
| APP (e1, e2) ->
    match (interp e1, interp e2) with
    | (ERROR s, _)  -> ERROR s          // ERRORs are propagated
    | (_, ERROR s)  -> ERROR s
    | (SUCC, NUM n) -> NUM (n+1)        // Rule (6)
    | (SUCC, v)     -> ERROR (sprintf "'succ' needs int argument, not '%A'" v)
    | (PRED, NUM 0) -> NUM 0            // Rule (7)
    | (PRED, NUM n) -> NUM (n-1)        // Rule (7)
    | (PRED, v) -> ERROR (sprintf "'pred' needs int argument, not '%A'" v)
    | (ISZERO, NUM 0) -> BOOL true      // Rule (8)
    | (ISZERO, NUM n) -> BOOL false     // Rule (8)
    | (ISZERO, v) -> ERROR (sprintf "'iszero' needs int argument, not '%A'" v)
    | (FUN (x, e), ex) -> interp (subst e x ex)                     // Rule (10)
    | (REC (x, f), e) -> interp (APP(subst f x (REC (x, f)), e))    // Rule (11)
    | (s1, s2) -> APP (s1, s2)

// Here are two convenient abbreviations for using your interpreter.
let interpfile filename = filename |> parsefile |> interp

let interpstr sourcecode = sourcecode |> parsestr |> interp