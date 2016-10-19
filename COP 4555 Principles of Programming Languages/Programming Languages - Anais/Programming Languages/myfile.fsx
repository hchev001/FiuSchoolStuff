let rec gcd = function
  | (a,0) -> a
  | (a,b) -> gcd (b, a % b);;

let (.+) (a,b) (c,d) = 
    let denom = b*d
    let top = ((denom/b) * a) + ((denom/d) * c)
    let div = gcd(top, denom);
    (top/div, denom/div);;

let (.*) (a,b) (c,d) = 
    let div = gcd(a*c, b*d)
    ((a*c)/div, (b*d)/div);;

let revlists alist = List.map List.rev alist;;
