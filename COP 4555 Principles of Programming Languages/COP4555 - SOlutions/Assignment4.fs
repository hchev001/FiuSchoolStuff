let makeMonitoredFun f =
    let c = ref 0
    (fun x -> c:= !c+1; printf "Called %d times.\n" !c; f x );;

let msqrt = makeMonitoredFun sqrt;;

//msqrt 16.0 + msqrt 25.0;;