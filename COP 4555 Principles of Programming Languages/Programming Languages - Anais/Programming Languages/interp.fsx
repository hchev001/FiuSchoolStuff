// This sets F# to read from whatever directory contains this source file.
System.Environment.set_CurrentDirectory __SOURCE_DIRECTORY__;;

#load "parser.fsx"

// This lets us refer to "Parser.Parse.parsefile" simply as "parsefile",
// and to constructors like "Parser.Parse.APP" simply as "APP".
open Parser.Parse

// Here I show you a little bit of the implementation of interp. Note how ERRORs
// are propagated, how rule (6) is implemented, and how stuck evaluations
// are reported using F#'s sprintf function to create good error messages.
let rec interp = function
| NUM n ->
    match (n) with
    |n >= 0 -> NUM n
    |_ -> ERROR (sprintf "num needs a non negative int argument")
| BOOL b -> 				//rule 2
    match (b) with
    | true -> BOOL true
    | false -> BOOL false
| IF (e1, e2, e3) -> 
    match (interp e1) with
    | BOOL true -> interp e2		//rule 4
    | BOOL false -> interp e3		//rule 5
    | _ -> ERROR (sprintf "if needs to be a boolean")
| APP (e1, e2) ->
    match (interp e1, interp e2) with
    | (ERROR s, _)  -> ERROR s        // ERRORs are propagated
    | (_, ERROR s)  -> ERROR s
    | (SUCC, NUM n) -> NUM (n+1)      // Rule (6)
    | (SUCC, v)     -> ERROR (sprintf "'succ' needs int argument, not '%A'" v)
    | (PRED, NUM 0) -> NUM 0
    | (PRED, NUM n) -> NUM (n-1)
    | (PRED, v) -> ERROR (sprintf "pred needs a non negative int argument, not '%A'" v)
    | (ISZERO, NUM 0) -> BOOL true
    | (ISZERO, NUM _) -> BOOL false


//let rec subst = function
//|ID var x t -> if var=x then t else




// Here are two convenient abbreviations for using your interpreter.
let interpfile filename = filename |> parsefile |> interp

let interpstr sourcecode = sourcecode |> parsestr |> interp