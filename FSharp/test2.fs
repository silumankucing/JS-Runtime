module FactorialExample

let rec factorial n =
    if n <= 1 then 1
    else n * factorial (n - 1)

[<EntryPoint>]
let main argv =
    let number = 5
    let result = factorial number
    printfn "The factorial of %d is %d" number result
    0