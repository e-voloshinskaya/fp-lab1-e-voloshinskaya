// Solve transcendental algebraic equations numerically
// using Bisection/Dichotomy (1), Iterations (2), Newton's (3) methods
type SM = System.Math
let eps = 0.000001


// 3 methods for solving equations
let rec dichotomy f (a: float) (b: float) =
    let x' = (a + b) / 2.
    
    if abs (f x') < eps then
        x'
    else
        if (f a) * (f x') < 0. then
            dichotomy f a x'
        else
            dichotomy f x' b

let rec iterations phi (x': float) =
    let eps = 0.000001

    if SM.Sqrt(x'**2. - (phi x')**2.) < eps then
        x'
    else
        let next = phi x'
        iterations phi next

let newton f df (x0: float) =
    let phi (x: float) = x - (f x)/(df x)
    iterations phi x0 // ! using function 'iterations'


// functions fi(x) with their derivatives dfi(x) and phi_i(x): x - phi(x) = fi(x)
// 1
let f1 x = 0.6*(3.**x) - 2.3*x - 3.
let df1 x = 0.6*(SM.Log 3.)*(3.**x) - 2.3
let phi1 x = SM.Log(5.*(2.3*x + 3.)/3.) / SM.Log(3)

// 2
let f2 x = x**2. - SM.Log(1.+ x) - 3.
let df2 x = 2.*x - 1./(1.+x)
let phi2 x = SM.Sqrt(SM.Log(1.+ x) + 3.)

// 3
let f3 x = (2.* x * SM.Sin x) - SM.Cos x
let df3 x = (3.* SM.Sin x) + (2.* x * SM.Cos x)
let phi3 x = 0.5 / SM.Atan x
//SM.Acos(2.* x * SM.Sin x)
//SM.Asin(SM.Cos x / (2.* x))


// solving equations with methods above + printing the resulting table
let main =
    printfn "----------------------------------------------"
    printfn "| #func | Dichotomy | Iterations |   Newton  |"
    printfn "----------------------------------------------"
    printfn "|   1   | %9.5f | %10.5f | %9.5f |" (dichotomy f1 2. 3.) (iterations phi1 2.5) (newton f1 df1 2.5)
    printfn "|   2   | %9.5f | %10.5f | %9.5f |" (dichotomy f2 2. 3.) (iterations phi2 2.5) (newton f2 df2 2.5)
    printfn "|   3   | %9.5f | %10.5f | %9.5f |" (dichotomy f3 0.4 1.) (iterations phi3 0.7) (newton f3 df3 0.7)
    printfn "----------------------------------------------"

main