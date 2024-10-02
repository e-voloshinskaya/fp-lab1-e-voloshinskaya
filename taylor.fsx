// Print a table of a given function f, computed by built-in functions vs by taylor series

// setting parameters
let f x = 1. / (2.*x - 5.)
let a = 0.
let b = 2.
let n = 10
let eps = 0.000001

// function to compute f using naive taylor series method
// x - point, n - number of iterations, acc - calculated function value
let taylor_naive (x: float) =
    let rec taylor_naive' (x: float) n (acc: float) =
        if abs (f x - acc) < eps then
            acc, n
        else
            let acc' = acc - (2.)**float(n-1) * (x)**float(n-1) / (5.)**float(n)
            taylor_naive' x (n+1) acc'
    taylor_naive' x 1 0.


// more efficient taylor series method
// prev - previous taylor member, curr - current taylor member
let taylor_smart (x: float) =
    let rec taylor_smart' (x: float) n (prev: float) (acc: float) =
        if abs (f x - acc) < eps then
            acc, n
        else
            let curr = prev * 2. * x / 5.
            let acc' = acc + curr
            taylor_smart' x (n + 1) curr acc'
    taylor_smart' x 2 -0.2 -0.2


// calculating + printing the resulting table
let main =
    printfn "--------------------------------------------------------------------------------------"
    printfn "|   x   |  Builtin  |     Naive Taylor     | # terms |     Smart Taylor    | # terms |"
    printfn "--------------------------------------------------------------------------------------"

    for i = 0 to n do
        let x = a + (float i) / (float n) * (b - a)
        let f1, n1 = taylor_naive x
        let f2, n2 = taylor_smart x
        printfn "|%7.2f|%11.6f|%22.6f|%9d|%21.6f|%9d|" x (f x) f1 n1 f2 n2
    // ! including the required number of iterations for each of the methods
    printfn "--------------------------------------------------------------------------------------"

main
